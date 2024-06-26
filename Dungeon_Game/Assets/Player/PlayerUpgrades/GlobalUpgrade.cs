using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GlobalUpgrade : PlayerUpgrade
{
    public GlobalUpgradetyp globalUpgradetyp;
    public float ammount;
    public override void UpgradeSelected(PlayerUpgradeManager player, int spellid)
    {
        player.ManageGlobalUpgrades(this);   
    }
}
