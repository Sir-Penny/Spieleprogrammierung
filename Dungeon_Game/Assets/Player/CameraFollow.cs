using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject playerCharacter;

    void Update()
    {
        transform.position = playerCharacter.transform.position;
    }
}
