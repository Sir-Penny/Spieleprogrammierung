using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invunrabel : MonoBehaviour
{
    public Collider bossCollider;
    private void OnTriggerEnter(Collider other)
    {
        bossCollider.enabled = true;
    }
}
