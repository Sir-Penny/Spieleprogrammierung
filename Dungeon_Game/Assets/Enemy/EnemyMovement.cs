using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform player;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;
        if (!player.gameObject.activeSelf)
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("walking",false);
        }
        else
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.destination = player.position;
            animator.SetBool("walking", true);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            navMeshAgent.speed = 0;
            navMeshAgent.isStopped = true;
            animator.SetBool("Attack",true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            navMeshAgent.speed = 2;
            navMeshAgent.isStopped = false;
            animator.SetBool("Attack",false);
        }
    }
}
