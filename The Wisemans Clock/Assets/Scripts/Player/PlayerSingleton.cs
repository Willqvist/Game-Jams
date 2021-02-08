using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    private static PlayerSingleton instance;
    
    private void Awake()
    {
        instance = this;
    }

    public Player gameObjectInstance;
    public ItemData emptyItem;
    
    public static PlayerSingleton Instance => instance;

    public Player getGameObject()
    {
        return gameObjectInstance;
    }

    public delegate void ItemChangedEvent(ItemData to);
    public static event ItemChangedEvent OnItemChanged;

    public bool CanPlayerMove { get; set; }

    private ItemData currentEquippedItem;
    public bool occupied = false;
    public bool hasSolvedSafe = false;
    public bool talkedToRats = false;
    public bool hasTalkedToBlixtenAfterRats  =false;
    public bool hasTalkedToNukeNote = false;
    public bool hasTalkedToStefanInsideHouse;

    public ItemType GetCurrentEquippedItemType()
    {
        return currentEquippedItem == null ? ItemType.EMPTY : currentEquippedItem.itemType;
    }

    public ItemData CurrentEquippedItem
    {
        get { return currentEquippedItem;  }
        set { if (this.GetCurrentEquippedItemType() != ItemType.EMPTY && value.itemType != ItemType.EMPTY) { ZToDrop.Instance.DropItem(); } OnItemChanged.Invoke(value); ZToDrop.Instance.playDropAudio(); currentEquippedItem = value;  }
    }

    public void dropCurrentItem()
    {
        if(this.GetCurrentEquippedItemType() != ItemType.EMPTY)
            ZToDrop.Instance.DropItem();
    }
}
