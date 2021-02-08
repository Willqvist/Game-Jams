using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutCollisionEnterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
            other.gameObject.GetComponent<PlayerThrowNut>().onEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
            other.gameObject.GetComponent<PlayerThrowNut>().onExit();
    }

    private void OnDisable()
    {
        PlayerSingleton.Instance.gameObjectInstance.GetComponent<PlayerThrowNut>().onExit();
    }
}
