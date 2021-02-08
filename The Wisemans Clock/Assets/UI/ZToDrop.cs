using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZToDrop : MonoBehaviour
{
    private static ZToDrop instance;
    public static ZToDrop Instance => instance;

    public delegate void ItemDroppedEvent(ItemData itemDropped);
    public static event ItemDroppedEvent OnItemDrop;

    public ItemData emptyItem;

    public AudioSource dropAudio;

    private bool disabled = false;

    private void Start()
    {
        instance = this;
        PlayerSingleton.OnItemChanged += PlayerSingleton_OnItemChanged;
    }

    public void playDropAudio()
    {
        this.dropAudio.Play();
    }

    public void DropItem()
    {
        if (PlayerSingleton.Instance.CurrentEquippedItem == null)
        {
            return;
        }

        if (PlayerSingleton.Instance.CurrentEquippedItem.spawnOnGroundOnDrop)
        {
            GameObject go = DropHelper.Drop(PlayerSingleton.Instance.CurrentEquippedItem.objectToSpawnOnGround);
            go.transform.position = PlayerSingleton.Instance.gameObjectInstance.feet.transform.position;
        }
        playDropAudio();
        PlayerSingleton.Instance.CurrentEquippedItem = emptyItem;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && !disabled)
        {
            DropItem();
        }
    }

    private void PlayerSingleton_OnItemChanged(ItemData to)
    {
        if(to.itemType == ItemType.EMPTY)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }

    public static void DisableDrop()
    {
        instance.disabled = true;
    }
    
    public static void EnableDrop()
    {
        instance.disabled = false;
    }
}
