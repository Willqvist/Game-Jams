using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemData : ScriptableObject
{
    public Texture uiImage;
    public ItemType itemType;

    public bool spawnOnGroundOnDrop;
    public GameObject objectToSpawnOnGround;
}

public enum ItemType
{
    EMPTY,
    NUT,
    SAW,
    SQUIRRLE,
    CAT,
    COBWEB
}
