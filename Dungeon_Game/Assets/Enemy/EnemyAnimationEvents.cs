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
        if (enemyMovement.attackRange.radius != enemyMovement.enemySpellPrefab[0].attackRange)
        {
            enemyMovement.inAttackRange = false;
        }
        enemyMovement.attackRange.radius = enemyMovement.enemySpellPrefab[0].attackRange;
        enemyMovement.attack = enemyMovement.enemySpellPrefab[0];
        if (enemyMovement.AttackCollider)
        {
            enemyMovement.AttackCollider.enabled = false;
        }
        if (enemyMovement.enemySpellPrefab.Length > 1)
        {
            animator.SetFloat("SpellAnimation", 0);
        }
        enemyMovement.attackAnimation = false;
    }
}
