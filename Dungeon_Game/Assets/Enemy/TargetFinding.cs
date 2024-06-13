using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinding : MonoBehaviour
{
    public EnemyStats enemyStats;

    private SphereCollider sphereCollider;
    private bool playerInRange=false;
    private GameObject enemy;

    public LayerMask layersToIgnore;
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = enemyStats.targetRange;
    }

    void Update()
    {
        if (playerInRange&&!enemyStats.foundEnemy)
        {
            Vector3 originPosition = transform.position+Vector3.up;
            Vector3 targetPosition = enemy.transform.position + Vector3.up;
            Vector3 direction = (targetPosition - originPosition);
            if (Physics.Raycast(originPosition, direction, out RaycastHit hit, enemyStats.targetRange,~layersToIgnore))
            {
                Debug.DrawRay(originPosition, direction, Color.green, 0.1f, false);
                if (hit.transform.gameObject.layer == 7) {
                    enemyStats.foundEnemy = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy = other.gameObject;
            playerInRange = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player"&&!enemyStats.foundEnemy)
        {
            playerInRange = false;
            enemy = null;
        }
    }
}
