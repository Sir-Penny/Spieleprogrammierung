using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class SpellPrefab : ScriptableObject
{
    public GameObject prefab;
    public SpellCastType spellCastType;
    public Vector3 spawmPosition;
    public Vector3 spawmRotation;
    public float manaCost;
    public Sprite image;
}

public enum SpellCastType
{
    PlayerPos,
    ThrowPos,
    MousePos
}