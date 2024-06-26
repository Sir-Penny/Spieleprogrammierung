using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public float exp=0;
    public float maxexp;
    public Slider sliderUI;

    public GameObject LevelUpWindow;


    public void UpdateExpBar()
    {
        sliderUI.value = exp / maxexp;
    }
    public void ReciveExp(int ammount)
    {
        exp += ammount;
        if(exp >= maxexp)
        {
            float overload = maxexp - exp;
            Time.timeScale = 0;
            LevelUpWindow.GetComponent<SkillUpgradeManager>().InitalizeUpgrades();
            maxexp *=  1.5f;
            exp = overload;
        }
        UpdateExpBar();
    }
}
