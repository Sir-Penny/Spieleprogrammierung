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
            enemyRoot.GetComponent<EnemyMovement>().enabled = false;
            enemyRoot.GetComponent<NavMeshAgent>().isStopped = true;
            Destroy(HelthBar);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            animator.SetBool("Death", true);
            this.enabled = false;
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
