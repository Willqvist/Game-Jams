using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemImage : MonoBehaviour
{
    [HideInInspector] public ItemData item;
    private RawImage rawImage;

    private void Start()
    {
        PlayerSingleton.OnItemChanged += PlayerSingleton_OnItemChanged;
        this.rawImage = GetComponent<RawImage>();
    }

    private void PlayerSingleton_OnItemChanged(ItemData to)
    {
        this.SetItem(to);
    }

    private void SetItem(ItemData to)
    {
        this.item = to;
        this.rawImage.texture = to.uiImage;
    }
}
