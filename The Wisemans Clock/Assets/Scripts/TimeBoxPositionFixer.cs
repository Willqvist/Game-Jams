using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBoxPositionFixer : MonoBehaviour
{

    public Transform teleportTo;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.name.Equals("Player")) return;
        other.gameObject.GetComponent<CharacterController>().enabled = false;
        other.gameObject.transform.position = teleportTo.position;
        other.gameObject.GetComponent<CharacterController>().enabled = true;
    }
}
