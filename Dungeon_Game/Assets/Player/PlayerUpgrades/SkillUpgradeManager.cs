using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillUpgradeManager : MonoBehaviour
{
    public PlayerUpgradeManager playerUpgradeManager;
    public GameObject upgradsCanvas;
    public GameObject[] upgrads;
    public List<PlayerUpgrade> playerUpgrades = new List<PlayerUpgrade>();
    public PlayerUpgrade[] removedUpgrades = new PlayerUpgrade[3];

    public void InitalizeUpgrades()
    {
        if(playerUpgrades.Count < 3)
        {
            Time.timeScale = 1;
            return;
        }
        for (int i = 0; i < upgrads.Length; i++)
        {
            Button button = upgrads[i].GetComponent<Button>();
            button.onClick.RemoveAllListeners();
        }
        for (int i = 0; i < 3; i++)
        {
            int r = Random.Range(0, playerUpgrades.Count);
            PlayerUpgrade upgrade = playerUpgrades[r];
            upgrads[i].GetComponent<Button>().onClick.AddListener(() => OnClickUpgrade(upgrade));
            upgrade.displayUpgrade(upgrads[i].transform.GetChild(0).GetComponent<TMP_Text>(), upgrads[i].transform.GetChild(1).GetComponent<TMP_Text>());
            removedUpgrades[i]=upgrade;
            playerUpgrades.RemoveAt(r);
        }
        upgradsCanvas.SetActive(true);
    }
    public void OnClickUpgrade(PlayerUpgrade playerUpgrade)
    {
        upgradsCanvas.SetActive(false);
        for (int i = 0; i < 3; i++)
        {
            if (!(removedUpgrades[i] == playerUpgrade&& removedUpgrades[i].playerUpgaredTypes != PlayerUpgaredTypes.global))
            {
                playerUpgrades.Add(removedUpgrades[i]);
            }
        }
        playerUpgrade.UpgradeSelected(playerUpgradeManager);
        Time.timeScale = 1;
    }
}
