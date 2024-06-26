using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Prefab;
    public Vector2 range;
    public int number;
    void Start()
    {
        for(int i = 0; i < number; i++)
        {
             Instantiate(Prefab, transform.localPosition + new Vector3(Random.Range(range.y * -1, range.x), 0.5f, Random.Range(range.y * -1, range.y)),Quaternion.identity);
        }
    }
}
