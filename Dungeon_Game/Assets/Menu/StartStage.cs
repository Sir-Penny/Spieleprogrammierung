using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StartStage : MonoBehaviour
{
    void Awake()
    {
        Time.timeScale = 1;
        GameObject player=GameObject.FindGameObjectWithTag("PlayerAI");
        player.GetComponent<NavMeshAgent>().enabled = false;
        player.transform.position = transform.position+Vector3.up;
        player.GetComponent<NavMeshAgent>().enabled = true;
    }
}
