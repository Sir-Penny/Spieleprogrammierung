using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    public GameObject flame;
    public GameObject flamethrower;
    public ParticleSystem flamethrowerps;
    public GameObject player;
    public float seconds;
    public float duration;
    public float damage;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        flamethrowerps.trigger.AddCollider(player.GetComponent<CapsuleCollider>());
    }
    public IEnumerator ActivateFlaemThrower()
    {
        yield return new WaitForSeconds(seconds);
        flamethrower.SetActive(true);
        StartCoroutine(StopEffect());
    }

    public IEnumerator StopEffect()
    {
        yield return new WaitForSeconds(duration);
        flamethrower.SetActive(false);
        flame.SetActive(false);
    }
    public void ActivateFlaemThrowerEffect()
    {
        flame.SetActive(true);
        StartCoroutine(ActivateFlaemThrower());
    }
}
