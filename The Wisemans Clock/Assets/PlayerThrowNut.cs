using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowNut : MonoBehaviour
{
    public BoxCollider nutThrowingTrigger;
    public GameObject interactableObject;
    public GameObject throwNutText;
    public GameObject interactableObjectOrigin;
    public GameObject nutToThrow;
    public Animator animator;

    private GameObject interactableObjectInstance;
    private GameObject throwNutTextInstance;
    private bool entered;
    private bool thrown;
    private bool moveNutTowardsTarget;
    private GameObject nutInstance;

    private Vector3 throwPosition;
    private float time = 1f;
    private bool playedAnimation;

    private void Start()
    {
        interactableObjectInstance = DropHelper.Drop(interactableObject);
        interactableObjectInstance.SetActive(false);
        interactableObjectInstance.transform.parent = GameObject.FindGameObjectWithTag("DialogueCanvas").transform;
        interactableObjectInstance.transform.localScale = Vector3.one;
        //interactableObjectInstance.GetComponent<RectTransform>().localScale = Vector3.one;

        throwNutTextInstance = DropHelper.Drop(throwNutText);
        throwNutTextInstance.SetActive(false);
        throwNutTextInstance.transform.parent = GameObject.FindGameObjectWithTag("DialogueCanvas").transform;
        throwNutTextInstance.transform.localScale = Vector3.one;
    }

    private void Update()
    {
        if (entered)
        {
            interactableObjectInstance.transform.position = Camera.main.WorldToScreenPoint(this.interactableObjectOrigin.transform.position);
            throwNutTextInstance.transform.position = Camera.main.WorldToScreenPoint(this.interactableObjectOrigin.transform.position + new Vector3(0, 0.25f, 0));

            if (!thrown && Input.GetKeyDown(KeyCode.E))
            {
                PlayerSingleton.Instance.CurrentEquippedItem = PlayerSingleton.Instance.emptyItem;
                nutInstance = DropHelper.Drop(this.nutToThrow);
                nutInstance.transform.position = this.transform.position;//this.interactableObjectOrigin.transform.position;
                PlayerSingleton.Instance.occupied = true;
                thrown = true;
                this.throwPosition = nutInstance.transform.position;
            }
        }

        if (thrown)
        {

            if (Vector3.Distance(nutInstance.transform.position, NutThrowingPointSingleton.Instance.transform.position) <= 0.2f)
            {
                time -= Time.deltaTime;
                if (time <= 0 && !playedAnimation)
                {
                    animator.Play("SquirrleChase");
                    playedAnimation = true;
                }
            }
            else
            {
                nutInstance.transform.position += (NutThrowingPointSingleton.Instance.transform.position - nutInstance.transform.position).normalized * 0.01f;
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if(PlayerSingleton.Instance.GetCurrentEquippedItemType() != ItemType.NUT)
        {
            interactableObjectInstance.SetActive(false);
            throwNutTextInstance.SetActive(false);
            entered = false;
            return;
        }


    }

    private void OnTriggerExit(Collider other)
    {

    }

    public void onEnter()
    {
        interactableObjectInstance.SetActive(true);
        entered = true;

        throwNutTextInstance.SetActive(true);
    }

    public void onExit()
    {
        interactableObjectInstance.SetActive(false);
        throwNutTextInstance.SetActive(false);
        entered = false;
    }
}
