using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpellOnEnemyHit : SkillUpgradePrefab
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 13)
        {
            Instantiate(prefab, other.transform.position + prefab.transform.position, prefab.transform.rotation);
        }
    }
}
