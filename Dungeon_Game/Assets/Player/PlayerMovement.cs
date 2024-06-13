using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Camera playerCame;
    public SpellPrefab[] spells;
    public GameObject spellCastPoint;
    private Animator animator;
    private bool spellAniamtion = false;
    public bool throwSpell=false;
    public LayerMask mouseInputIgnoreLayers;
    public SpellPrefab spell;
    public float playerSpeed = 5;
    private Vector3 spellMousePos = Vector3.zero;
    public bool groundhit;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
        navMeshAgent.speed = playerSpeed;
    }
    void Update()
    {

        Vector3 mouseWorldPos=Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~mouseInputIgnoreLayers))
        {
            mouseWorldPos = hit.point;
            groundhit = true;
            if (Input.GetMouseButton(0) && spellAniamtion == false)
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.destination = hit.point;
            }
        }
        else {
            groundhit = false;
        }
        if (navMeshAgent.remainingDistance < 0.1)
        {
            animator.SetBool("WalkingPlayer", false);
        }
        else
        {
            animator.SetBool("WalkingPlayer", true);
        }

        //TODO add Cast time instead of using animation Events
        if (Input.GetKeyDown(KeyCode.Q)&& spellAniamtion == false)
        {
            spell = spells[0];
            StartAttacke(mouseWorldPos);
        }
        if (Input.GetKeyDown(KeyCode.W) && spellAniamtion == false)
        {
            spell = spells[1];
            StartAttacke(mouseWorldPos);
        }
        if (Input.GetKeyDown(KeyCode.E)&& spellAniamtion == false)
        {
            spell = spells[2];
            StartAttacke(mouseWorldPos);
        }   
        if (throwSpell)
        {
            if (spell.spellCastType == SpellCastType.PlayerPos)
            {
                Instantiate(spell.prefab, transform.position+spell.spawmPosition, transform.rotation*Quaternion.Euler(spell.spawmRotation));
                throwSpell = false;
                spellAniamtion = false;
            }
            if (spell.spellCastType == SpellCastType.ThrowPos)
            {
                Instantiate(spell.prefab, spellCastPoint.transform.position + spell.spawmPosition, transform.rotation * Quaternion.Euler(spell.spawmRotation));
                throwSpell = false;
                spellAniamtion = false;
            }
            if (spell.spellCastType == SpellCastType.MousePos)
            {
                Instantiate(spell.prefab, spellMousePos + spell.spawmPosition, transform.rotation * Quaternion.Euler(spell.spawmRotation));
                throwSpell = false;
                spellAniamtion = false;
            }
        }
    }

    public void StartAttacke(Vector3 mouseWorldPos)
    {
        spellAniamtion = true;
        navMeshAgent.destination = transform.position;
        navMeshAgent.isStopped = true;
        animator.SetBool("Throwing", true);
        animator.SetBool("WalkingPlayer", false);
        Vector3 lookPos = mouseWorldPos - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
        spellMousePos = mouseWorldPos;
    }
}