using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Camera playerCame;
    public GameObject Fireball;
    public GameObject spellCastPoint;
    private Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 lookPos = hit.point - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = rotation;
        }
        print(navMeshAgent.isStopped);
        
        if (navMeshAgent.remainingDistance < 0.1)
        {
            animator.SetBool("WalkingPlayer", false);
            //print("WalkingPlayer false");
        }
        else
        {
            animator.SetBool("WalkingPlayer", true);
            //print("WalkingPlayer true");
        }
            if (Input.GetMouseButton(0))
        {
            navMeshAgent.destination = hit.point;
        }

        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //navMeshAgent.speed = 0;
            //navMeshAgent.isStopped = true;
            //animator.SetBool("WalkingPlayer", false);
            animator.SetTrigger("Throwing");
            print("Throw true");
            Instantiate(Fireball, spellCastPoint.transform.position, spellCastPoint.transform.rotation);
        }
    }
}