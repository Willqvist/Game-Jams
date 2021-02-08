using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRatDropDialogue : MonoBehaviour
{

    public GameObject PlayerUI;
    public Collider colliderToEnable;
    public Animator ratAnimator;
    public GameObject dropCatObj;
    public Transform pos;
    public ItemData emptyItem;
    private bool inside = false;
    public EasyDialogue ratTalk;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.E) &&
            PlayerSingleton.Instance.GetCurrentEquippedItemType() == ItemType.CAT)
        {
            ratAnimator.SetBool("start",true);
            GameObject inst = DropHelper.Drop(dropCatObj);
            inst.transform.position = pos.position;
            inst.GetComponent<Animator>().SetBool("start",true);
            PlayerSingleton.Instance.CurrentEquippedItem = emptyItem;
            PlayerUI.SetActive(false);
            colliderToEnable.gameObject.SetActive(true);
            ratTalk.disable();
            //TODO: start animation and remove rats.
            QuestHelper.Instance.SetText("");
        }
        else if (inside && PlayerSingleton.Instance.GetCurrentEquippedItemType() != ItemType.CAT && PlayerUI.activeSelf)
        {
            PlayerUI.SetActive(false);
        }
        else if (inside && PlayerSingleton.Instance.GetCurrentEquippedItemType() == ItemType.CAT && !PlayerUI.activeSelf)
        {
            PlayerUI.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerSingleton.Instance.GetCurrentEquippedItemType() == ItemType.CAT)
        {
            PlayerUI.SetActive(true);
            inside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inside = false;
        PlayerUI.SetActive(false);
    }
}
