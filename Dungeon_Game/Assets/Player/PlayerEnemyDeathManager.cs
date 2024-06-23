using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyDeathManager : MonoBehaviour
{
    public PlayerExp playerExp;

    public void AddOnEnemyDeath(int expAmmount)
    {
        playerExp.ReciveExp(expAmmount);
    }
}
