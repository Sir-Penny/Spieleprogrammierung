using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public EnemyStats enemyStats;
    private NavMeshAgent navMeshAgent;
    private Transform player;
    private Animator animator;
    public SphereCollider attackRange;
    public bool inAttackRange=false;
    public bool attackAnimation=false;
    public GameObject CastPoint;

    public EnemySpellPrefab[] enemySpellPrefab;
    public EnemySpellPrefab attack;
    public bool fireAttack;
    public Collider AttackCollider;
    public Quaternion attackRotation;
    public bool globalAbilityCooldown;

    private bool init=false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
        navMeshAgent.speed = enemyStats.moveSpeed;
        attackRange.radius = enemySpellPrefab[0].attackRange;
        attack = enemySpellPrefab[0];
    }

    void Update()
    {
        if (enemyStats.foundEnemy)
        {
            if (player == null)
                return;
            if (!player.gameObject.activeSelf)
            {
                navMeshAgent.isStopped = true;
                animator.SetBool("walking", false);
            }
            else
            {
                navMeshAgent.destination = player.position;
                if (!init)
                {
                    animator.SetBool("walking", true);
                    init = true;
                    if (enemySpellPrefab.Length > 1)
                    {
                        StartCoroutine(UseOtherSpell());
                    }
                }
            }
        }
        if(inAttackRange && !attackAnimation)
        {
            attackAnimation = true;
            animator.SetTrigger("attack");
            Vector3 lookPos = player.position - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = rotation;
            if (attack.enemySpellCastType != EnemySpellCastType.Meele)
            {
                lookPos = player.position - CastPoint.transform.position;
                lookPos.y = 0;
                attackRotation = Quaternion.LookRotation(lookPos);
            }
            if (AttackCollider && attack.enemySpellCastType == EnemySpellCastType.Meele)
            {
                AttackCollider.enabled = true;
            }
        }
        if(!inAttackRange && !attackAnimation && navMeshAgent.isStopped)
        {
            animator.SetBool("walking", true);
            navMeshAgent.speed = enemyStats.moveSpeed;
            navMeshAgent.isStopped = false;
        }
        if (fireAttack)
        {
            fireAttack = false;
            if (attack.enemySpellCastType == EnemySpellCastType.Global)
            {
                 GameObject.FindGameObjectWithTag("GlobalAbility").GetComponent<GlobalAbility>().Activate();
            } else if (attack.enemySpellCastType == EnemySpellCastType.Ranged) {
                Instantiate(attack.spell, CastPoint.transform.position, attackRotation);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            navMeshAgent.speed = 0;
            navMeshAgent.isStopped = true;
            inAttackRange = true;
            animator.SetBool("walking", false);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inAttackRange = false;
        }
    }
    public IEnumerator UseOtherSpell()
    {
        while (true) {
            yield return new WaitForSeconds(1);
            if (!attackAnimation)
            {
                int randomSpell = Random.Range(0, enemySpellPrefab.Length);
                if (enemySpellPrefab[randomSpell].enemySpellCastType == EnemySpellCastType.Global)
                {
                    print(globalAbilityCooldown);
                    if (globalAbilityCooldown)
                        continue;
                    else
                        StartCoroutine(GlobalabilityCooldown(enemySpellPrefab[randomSpell].Cooldown));
                }
                animator.SetFloat("SpellAnimation", randomSpell);
                attack = enemySpellPrefab[randomSpell];
                attackRange.radius = attack.attackRange;
            }
        }
    }
    public IEnumerator GlobalabilityCooldown(float cooldown)
    {
        print("cooldownStart");
        globalAbilityCooldown = true;
        yield return new WaitForSeconds(cooldown);
        globalAbilityCooldown = false;
        print("cooldownEnd");
    }
}
