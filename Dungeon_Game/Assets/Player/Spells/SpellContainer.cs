using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellContainer
{
    public SpellPrefab spellPrefab;
    public KeyCode inputKey;
    public List<skillUpgrade> upgrades;

    public SpellContainer(SpellPrefab prefab,KeyCode keyCode)
    {
        spellPrefab = prefab;
        inputKey = keyCode;
        upgrades = new List<skillUpgrade>();
    }
}
