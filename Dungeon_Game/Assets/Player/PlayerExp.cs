using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    public int exp=0;
    public int maxexp;

    public GameObject LevelUpWindow;

    public void ReciveExp(int ammount)
    {
        exp += ammount;
        if(exp >= maxexp)
        {
            Time.timeScale = 0;
            LevelUpWindow.GetComponent<SkillUpgradeManager>().InitalizeUpgrades();
            maxexp *=  2;
        }
    }
}
