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
    }
}
