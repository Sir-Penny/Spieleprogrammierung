using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class skillUpgrade : PlayerUpgrade
{
    public Component skillUpgradeComponent;

    public override void UpgradeSelected(PlayerUpgradeManager player,int spellid)
    {
        player.AddSkillUpgrade(spellid,this);
    }
}
