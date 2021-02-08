using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimestampEntity : MonoBehaviour
{
    public string myTime;

    private static Dictionary<string, TimestampEntity> ents = new Dictionary<string, TimestampEntity>();
    private void Awake()
    {
        DropHelper.registerDropArea(myTime,this.gameObject);
        ents[myTime] = this;
    }

    public static TimestampEntity getEntity(string time)
    {
        return ents[time];
    }

    private void Start()
    {
        SmoothSlider.OnSlide += SmoothSlider_OnSlide;
        BabyTransition.OnBabyTransition += BabyTransition_OnBabyTransition;
        this.gameObject.SetActive(false);
        
        
    }

    private void BabyTransition_OnBabyTransition(bool to, GameObject old)
    {
        if(!this.myTime.Equals("baby") && to)
        {
            this.gameObject.SetActive(false);
            return;
        }
        if(!to && old != null)
            old.SetActive(true);
        this.gameObject.SetActive(to);
    }

    private void SmoothSlider_OnSlide(Timestamp timestamp)
    {
        if(timestamp.timestamp.Equals(myTime))
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
