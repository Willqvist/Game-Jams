using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{

    public delegate void onFade();

    private onFade currentCallback;

    private float speed = 0;
    
    private Color target = Color.black;

    private Color fadeInTarget = Color.black;
    private Color fadeOutTarget = new Color(0,0,0,0);

    private bool fading = false;

    public Image image;

    public static event onFade onFading;

    private static Fader instance;
    
    public static Fader Instance ()=> instance;

    private void Awake()
    {
        instance = this;
    }


    public void fadeIn(float speed, onFade fadeCallback)
    {
        fading = true;
        this.speed = speed;
        target = fadeInTarget;
        currentCallback = fadeCallback;
        onFading();
    }

    public void fadeOut(float speed, onFade fadeCallback)
    {
        fading = true;
        this.speed = speed;
        target = fadeOutTarget;
        currentCallback = fadeCallback;
        onFading();
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            this.image.color = Color.Lerp(this.image.color, target, Time.deltaTime * speed);
            if (Math.Abs(this.image.color.a - target.a) < 0.03)
            {
                fading = false;
                currentCallback.Invoke();
            }
        }
    }
}
