using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stonefall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }
    }
}
