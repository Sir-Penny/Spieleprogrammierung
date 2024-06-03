using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Camera playerCame;
    public GameObject Fireball;
    public GameObject Firering;
    public GameObject spellCastPoint;
    private Animator animator;
    private bool spellAniamtion = false;
    private bool splitSpellAnimation = false;
    private bool bombAnimation = false;
    public bool throwSpell=false;
    public LayerMask mouseInputIgnoreLayers;
    public GameObject spell;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,Mathf.Infinity, ~mouseInputIgnoreLayers))
        {
            if (Input.GetMouseButton(0)&& spellAniamtion == false)
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.destination = hit.point;
            }
        }
        if (navMeshAgent.remainingDistance < 0.1)
        {
            animator.SetBool("WalkingPlayer", false);
        }
        else
        {animator.SetBool("WalkingPlayer", true);
            
        }

        //TODO add Cast time instead of using animation Events
        if (Input.GetKeyDown(KeyCode.Q))
        {
            spell = Fireball;
            spellAniamtion = true;
            navMeshAgent.destination = transform.position;
            navMeshAgent.isStopped = true;
            animator.SetBool("Throwing", true);
            animator.SetBool("WalkingPlayer", false);
            Vector3 lookPos = hit.point - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = rotation;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            spell = Firering;
            splitSpellAnimation = true;
            navMeshAgent.destination = transform.position;
            navMeshAgent.isStopped = true;
            animator.SetBool("Throwing", true);
            animator.SetBool("WalkingPlayer", false);
            Vector3 lookPos = hit.point - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = rotation;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            bombAnimation = true;
            navMeshAgent.destination = transform.position;
            navMeshAgent.isStopped = true;
            animator.SetBool("Throwing", true);
            animator.SetBool("WalkingPlayer", false);
            Vector3 lookPos = hit.point - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = rotation;
        }
        if (throwSpell)
        {
            Instantiate(spell, spellCastPoint.transform.position, transform.rotation);
            throwSpell = false;
            spellAniamtion = false;
        }
    }
}