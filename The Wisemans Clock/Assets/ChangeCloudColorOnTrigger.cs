using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCloudColorOnTrigger : MonoBehaviour
{
    
    public Camera camera;
    public Color color;
    private Color prevColor;

    private bool cc = false;
    // Start is called before the first frame update
    void Start()
    {
        prevColor = camera.backgroundColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        cc = true;
        camera.backgroundColor = color;
        RenderSettings.fog = true;
        RenderSettings.fogColor = color;
        RenderSettings.fogDensity = 0.08f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (cc) return;
        OnTriggerEnter(other);
    }
    
    private void OnTriggerExit(Collider other)
    {
        cc = false;
        camera.backgroundColor = prevColor;
        RenderSettings.fog = false;
    }
}
