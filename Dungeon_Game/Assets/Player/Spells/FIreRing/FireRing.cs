using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRing : MonoBehaviour
{
    public float speed = 1.0f;
    void Update()
    {
        Vector3 transformSize = new Vector3(transform.localScale.x + speed, transform.localScale.y + speed, 1f);
        transform.localScale = transformSize;
        if(transformSize.x > 200)
        {
            Destroy(this.gameObject);
        }
    }
}
