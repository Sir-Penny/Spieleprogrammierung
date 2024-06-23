using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AddSkill : PlayerUpgrade
{
    public SpellPrefab skill;

    public override void UpgradeSelected(PlayerUpgradeManager player)
    {
        player.ManageAddSkill(this);
    }
}
