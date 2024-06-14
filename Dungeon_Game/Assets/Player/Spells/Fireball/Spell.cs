using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public float speed;
    public float lifetime;

    private void Awake()
    {
        Destroy(this.gameObject, lifetime);
    }

    private void Update()
     {
         if (speed > 0) 
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
     }

     private void OnTriggerEnter(Collider other)
     {
        print(other.gameObject);
         Destroy(this.gameObject);
     }
}
