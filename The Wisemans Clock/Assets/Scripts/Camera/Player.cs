using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement movementHandler;
    public GameObject feet;

    public void ChangePosition(Vector3 v)
    {
        this.GetComponent<CharacterController>().enabled = false;
        this.transform.position = v;
        this.GetComponent<CharacterController>().enabled = true;
    }

}
