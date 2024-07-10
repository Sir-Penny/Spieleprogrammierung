using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHelathManager : MonoBehaviour
{
    public GameObject HelthBar;
    public Slider slider;
    public EnemyStats enemyStats;
    private Camera playerCam;
    private float maxHealth;
    public Animator animator;
    public GameObject enemyRoot;

    private void Awake()
    {
        playerCam = Camera.main;
        maxHealth = enemyStats.health;
        slider.value = enemyStats.health;
        HelthBar.transform.LookAt(playerCam.transform);
    }
    private void Update()
    {
        HelthBar.transform.LookAt(playerCam.transform);
    }

    public void UpdateHelthBar()
    {
        slider.value = enemyStats.health/maxHealth;
    }

    public void ReciveDamge(float damage)
    {
        enemyStats.health -= damage;
        UpdateHelthBar();
        if (enemyStats.health <= 0)
        {
            enemyRoot.GetComponent<EnemyManager>().enabled = false;
            enemyRoot.GetComponent<NavMeshAgent>().isStopped = true;
            enemyRoot.GetComponent<NavMeshAgent>().enabled= false;
            Destroy(HelthBar);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            enemyRoot.GetComponent<CapsuleCollider>().enabled = false;
            animator.SetBool("Death", true);
            this.enabled = false;
            for (int i = 0; i < enemyRoot.GetComponent<EnemyManager>().AttackCollider.Length; i++)
            {
                enemyRoot.GetComponent<EnemyManager>().AttackCollider[i].enabled = false;
            }
            enemyStats.target.GetComponent<PlayerEnemyDeathManager>().AddOnEnemyDeath(enemyStats.exp);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Spell")
        {
            SpellDamage spellDamage = other.gameObject.GetComponent<SpellDamage>();
            if (!spellDamage.CheckIfHit(this.gameObject))
            {
                spellDamage.addToHitLIst(this.gameObject);
                ReciveDamge(spellDamage.Damage);
            }
        }
    }
}
