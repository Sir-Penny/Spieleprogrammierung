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
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                navMeshAgent.destination = hit.point;
            } 
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(Fireball, spellCastPoint.transform.position, spellCastPoint.transform.rotation);
        }
    }
}
