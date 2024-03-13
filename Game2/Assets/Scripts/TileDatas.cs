using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum FloorType
{
    Floor,
    Carpet,
}

[CreateAssetMenu]

public class TileDatas : ScriptableObject
{
    public TileBase[] tiles;
    public AudioClip[] clip;
    public FloorType floorType;
}