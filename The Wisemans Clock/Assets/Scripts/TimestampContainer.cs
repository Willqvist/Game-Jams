using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimestampContainer : MonoBehaviour
{
    private GameObject previousTime;

    void Start()
    {
        SmoothSlider.OnSlide += SmoothSlider_OnSlide;
    }

    private void SmoothSlider_OnSlide(Timestamp timestamp)
    {
        if(this.previousTime != null)
        {
            this.previousTime.SetActive(false);
        }

        Transform child = this.transform.Find(timestamp.timestamp.ToString());
        child.gameObject.SetActive(true);
        this.previousTime = child.gameObject;
    }
}
