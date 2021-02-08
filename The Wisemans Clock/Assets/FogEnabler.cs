using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogEnabler : MonoBehaviour
{

    public float fogDensityTarget = 0.453f;
    
    private Color color;

    private Color target;
    private float targetDensity = 0.08f;
    private bool animate = false;

    public float fadeSpeed = 0.6f;

    private Camera camera;

    private bool inside = false;

    //public Color fogColor;
    // Start is called before the first frame update
    void Start()
    {
        color = Camera.main.backgroundColor;
        color = new Color(color.r,color.g,color.b);
        camera = Camera.main;

        SmoothSlider.OnSlide += SmoothSlider_OnSlide;
    }

    // Update is called once per frame
    void Update()
    {
        if (animate)
        {
            camera.backgroundColor = Color.Lerp(camera.backgroundColor, target, fadeSpeed * Time.deltaTime);
            RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity,targetDensity,fadeSpeed* Time.deltaTime);
            /*
            if (Mathf.Abs(RenderSettings.fogDensity - targetDensity) < 0.02)
            {
                animate = false;
                RenderSettings.fogDensity = targetDensity;
                camera.backgroundColor = target;
            }
            */
        }
    }

    private void SmoothSlider_OnSlide(Timestamp timestamp)
    {
        RenderSettings.fog = false;
        RenderSettings.fogDensity = 0;
        if(camera)
            camera.backgroundColor = color;
        inside = false;
    }

    //TODO: fade in shade...

    private void OnTriggerEnter(Collider other)
    {
        RenderSettings.fog = true;
        RenderSettings.fogDensity = 0;
        target = RenderSettings.fogColor;
        targetDensity = fogDensityTarget;
        animate = true;
        inside = true;
    }

    private void OnDisable()
    {
        RenderSettings.fog = false;
        RenderSettings.fogDensity = 0;
        if(camera)
        camera.backgroundColor = color;
        inside = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (inside) return;
        if (!other.gameObject.name.Equals("Player")) return;
        OnTriggerEnter(other);
    }


    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.name.Equals("Player")) return;
        inside = false;
        RenderSettings.fogDensity = fogDensityTarget;
        target = color;
        targetDensity = 0;
        animate = true;
    }
}
