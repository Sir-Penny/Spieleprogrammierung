using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvents : MonoBehaviour
{
    public Animator animator;
    public EnemyMovement enemyMovement;
    public void FireAttack()
    {
        enemyMovement.fireAttack = true;
    }

    public void AnimationEnd()
    {
        enemyMovement.attackAnimation = false;
        enemyMovement.attackRange.radius = enemyMovement.enemySpellPrefab[0].attackRange;
        enemyMovement.attack = enemyMovement.enemySpellPrefab[0].spell;
        if (enemyMovement.AttackCollider)
        {
            enemyMovement.AttackCollider.enabled = false;
        }
    }
}
