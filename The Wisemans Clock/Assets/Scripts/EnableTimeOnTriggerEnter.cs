using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTimeOnTriggerEnter : MonoBehaviour
{
    
    public GameObject SliderUI;

    public bool setAsActive = true;
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
        SliderUI.SetActive(setAsActive);
    }
}
