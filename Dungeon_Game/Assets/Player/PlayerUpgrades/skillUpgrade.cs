using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class skillUpgrade : PlayerUpgrade
{
    public string scriptType;
    public GameObject pefab;

    public override void UpgradeSelected(PlayerUpgradeManager player,int spellid)
    {
        player.AddSkillUpgrade(spellid,this);
    }
}

