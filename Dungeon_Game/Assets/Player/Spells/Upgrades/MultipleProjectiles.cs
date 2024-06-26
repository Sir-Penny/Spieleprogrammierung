using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleProjectiles : SkillUpgradePrefab
{
    void Start()
    {
        GameObject go = this.gameObject;
        Destroy(go.GetComponent<MultipleProjectiles>());
        Instantiate(this.gameObject, transform.position, transform.rotation * Quaternion.Euler(0, 30, 0));
        Instantiate(this.gameObject, transform.position, transform.rotation * Quaternion.Euler(0, -30, 0));
    }
}
