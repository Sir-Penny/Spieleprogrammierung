using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GlobalUpgrade : PlayerUpgrade
{
    public GlobalUpgradetyp globalUpgradetyp;
    public int ammount;
    public override void UpgradeSelected(PlayerUpgradeManager player)
    {
        player.ManageGlobalUpgrades(this);   
    }
}
