using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class SpellPrefab : ScriptableObject
{
    public int spellid;
    public GameObject prefab;
    public SpellCastType spellCastType;
    public Vector3 spawmPosition;
    public Vector3 spawmRotation;
    public float manaCost;
    public Sprite image;
    public List<PlayerUpgrade> skillUpgrades = new List<PlayerUpgrade>();
}

public enum SpellCastType
{
    PlayerPos,
    ThrowPos,
    MousePos
}