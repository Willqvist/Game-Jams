using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnNutInteract : MonoBehaviour
{
    public ItemData itemToRecieve;

    public void OnInteraction()
    {
        PlayerSingleton.Instance.CurrentEquippedItem = itemToRecieve;
        Destroy(this.gameObject);
    }
}
