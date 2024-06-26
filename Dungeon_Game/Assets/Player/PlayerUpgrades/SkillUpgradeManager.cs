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
    public List<playerUpgradesContainer> playerUpgrades = new List<playerUpgradesContainer>();
    public playerUpgradesContainer[] removedUpgrades = new playerUpgradesContainer[3];

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
            playerUpgradesContainer upgrade = playerUpgrades[r];
            upgrads[i].GetComponent<Button>().onClick.AddListener(() => OnClickUpgrade(upgrade));
            upgrade.playerUpgrade.displayUpgrade(upgrads[i].transform.GetChild(0).GetComponent<TMP_Text>(), upgrads[i].transform.GetChild(1).GetComponent<TMP_Text>());
            removedUpgrades[i]=upgrade;
            playerUpgrades.RemoveAt(r);
        }
        upgradsCanvas.SetActive(true);
    }
    public void OnClickUpgrade(playerUpgradesContainer playerUpgrade)
    {
        upgradsCanvas.SetActive(false);
        for (int i = 0; i < 3; i++)
        {
            if (!(removedUpgrades[i] == playerUpgrade&& removedUpgrades[i].playerUpgrade.playerUpgaredTypes != PlayerUpgaredTypes.global))
            {
                playerUpgrades.Add(removedUpgrades[i]);
            }
        }
        playerUpgrade.playerUpgrade.UpgradeSelected(playerUpgradeManager,playerUpgrade.spellid);
        Time.timeScale = 1;
    }
}

[System.Serializable]
public class playerUpgradesContainer
{
    public PlayerUpgrade playerUpgrade;
    public int spellid;

    public playerUpgradesContainer(PlayerUpgrade playerUpgrade)
    {
        this.playerUpgrade = playerUpgrade;
        spellid = -1;
    }
    public playerUpgradesContainer(PlayerUpgrade playerUpgrade,int spellid)
    {
        this.playerUpgrade = playerUpgrade;
        this.spellid = spellid;
    }
}
