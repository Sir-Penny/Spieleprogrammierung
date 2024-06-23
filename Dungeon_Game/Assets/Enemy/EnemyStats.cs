using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public float health;
    public float damage;
    public float targetRange;
    public float attackRange;
    public float moveSpeed;
    public float attackDamage;

    public int exp;

    public bool foundEnemy = false;
    public GameObject target;
}
