using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeManager : MonoBehaviour
{
    public PlayerHealthManager playerHealthManager;
    public PlayerManaManager playerManaManager;
    public PlayerManager playerMovement;
    public void AddMaxHealth(float ammount)
    {
        playerHealthManager.health += ammount;
        playerHealthManager.maxHealth += ammount;
    }
    public void IncreaseManaReg(float ammount)
    {
        playerManaManager.regenerationAmmount += ammount;
    }
    public void IncreaseHeathReg(float ammount)
    {
        playerHealthManager.regenerationAmmount += ammount;
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
        if (upgrade.globalUpgradetyp == GlobalUpgradetyp.HealthReg)
        {
            IncreaseHeathReg(upgrade.ammount);
        }
        if (upgrade.globalUpgradetyp == GlobalUpgradetyp.ManaReg)
        {
            IncreaseManaReg(upgrade.ammount);
        }
    }

    public void ManageAddSkill(AddSkill upgrade)
    {
        playerMovement.AddSpell(upgrade.skill);
    }

    public void AddSkillUpgrade(int spellid,skillUpgrade upgrade)
    {
        playerMovement.AddSpellUpgrade(spellid, upgrade);
    }
}

public enum GlobalUpgradetyp
{
    AddMaxHealth,
    AddDamage,
    HealthReg,
    ManaReg
}
