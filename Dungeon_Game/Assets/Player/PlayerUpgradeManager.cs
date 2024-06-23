using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeManager : MonoBehaviour
{
    public PlayerHealthManager playerHealthManager;
    public PlayerMovement playerMovement;
    public void AddMaxHealth(float ammount)
    {
        playerHealthManager.health += ammount;
        playerHealthManager.maxHealth += ammount;
    }

    public void AddDammage(float ammount)
    {
        playerMovement.damage += ammount;
    }

    public void ManageGlobalUpgrades(GlobalUpgrade upgrade)
    {
        if(upgrade.globalUpgradetyp == GlobalUpgradetyp.AddMaxHealth)
        {
            AddMaxHealth(upgrade.ammount);
        }
        if (upgrade.globalUpgradetyp == GlobalUpgradetyp.AddDamage)
        {
            AddDammage(upgrade.ammount);
        }
    }

    public void ManageAddSkill(AddSkill upgrade)
    {
        playerMovement.AddSpell(upgrade.skill);
    }

}

public enum GlobalUpgradetyp
{
    AddMaxHealth,
    AddDamage,
}
