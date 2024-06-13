using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorCallBack : MonoBehaviour
{
    private Animator animator;
    public PlayerMovement playerMovement;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void throwEnd()
    {
        playerMovement.throwSpell = true;
    }
}
