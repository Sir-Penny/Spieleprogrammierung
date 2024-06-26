using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EnemySpawnAreaViualizer : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    void Start()
    {
#if !UNITY_EDITOR
    // Disable the plane in build (runtime)
    gameObject.SetActive(false);
#endif
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Application.isPlaying)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            float planeWidth = 10f;
            float planeHeight = 10f;

            Vector3 newScale = new Vector3(enemySpawner.range.x*2 / planeWidth, 1, enemySpawner.range.y*2 / planeHeight);
            transform.localScale = newScale;
            transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
        }
#endif
    }
}