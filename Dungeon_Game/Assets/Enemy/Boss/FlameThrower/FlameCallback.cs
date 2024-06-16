using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCallback : MonoBehaviour
{
    public FlameThrower flameThrower;
    private void OnParticleTrigger()
    {
        flameThrower.player.GetComponent<PlayerHealthManager>().ReciveDamge(flameThrower.damage);
    }
}
