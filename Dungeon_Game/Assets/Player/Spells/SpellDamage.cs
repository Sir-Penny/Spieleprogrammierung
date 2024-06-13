using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamage : MonoBehaviour
{
    public float Damage;
    public List<GameObject> hitEnemys= new List<GameObject>();

    public void addToHitLIst(GameObject enemy)
    {
        hitEnemys.Add(enemy);
    }
    public bool CheckIfHit(GameObject enemy)
    {
        if (hitEnemys.Contains(enemy))
        {
            return true;
        }
        return false;
    }
}
