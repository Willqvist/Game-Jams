using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFadeout : MonoBehaviour
{
    private static CameraFadeout instance;
    public static CameraFadeout Instance => instance;

    public FADE_IN cameraFadeout;
    private float fadeoutTimer = 0f;
    private bool fadeout;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(!this.fadeout)
        {
            return;
        }
    }

    public void FadeOut()
    {
        cameraFadeout.startFadeIn();
    }
}
