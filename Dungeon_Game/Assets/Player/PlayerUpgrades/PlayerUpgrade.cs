using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public abstract class PlayerUpgrade : ScriptableObject
{
    public PlayerUpgaredTypes playerUpgaredTypes;
    public string upgradeName;
    public string upgradeDescription;

    public abstract void UpgradeSelected(PlayerUpgradeManager player, int spellid);

    public void displayUpgrade(TMP_Text name, TMP_Text description)
    {
        name.text = upgradeName;
        description.text = upgradeDescription;
    }
}

public enum PlayerUpgaredTypes{
    addSkill,
    skillUpgared,
    global
}
