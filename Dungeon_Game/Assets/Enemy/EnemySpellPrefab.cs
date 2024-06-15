using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemySpellPrefab : ScriptableObject
{
    public GameObject spell;
    public float Cooldown;
    public EnemySpellCastType enemySpellCastType;
    public float attackRange;
}

public enum EnemySpellCastType
{
    Ranged,
    Meele,
    Global
}
