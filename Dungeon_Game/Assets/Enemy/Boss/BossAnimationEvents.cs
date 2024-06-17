using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationEvents : EnemyAnimationEvents
{
    public GameObject gameWinUI;
    public void BossDeathAnimiationEnd()
    {
        Time.timeScale = 0;
        gameWinUI.SetActive(true);
    }
}
