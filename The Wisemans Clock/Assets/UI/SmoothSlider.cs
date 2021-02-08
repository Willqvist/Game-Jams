using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SmoothSlider : MonoBehaviour
{
    private static SmoothSlider instance;
    public static SmoothSlider Instance => instance;

    public delegate void SlideEvent(Timestamp timestamp);
    public static event SlideEvent OnSlide;
    public static event SlideEvent OnStartSlide;
    public RectTransform handleRect;
    public Timestamp[] timestamps;
    public SlidingBackground slidingBackground;

    private int slideIndex;
    private float waitTime = 0.1f;
    private bool slid;
    private bool doneIntro = false;

    private bool sliding;
    private bool Sliding
    {
        get
        {
            return sliding;
        }
        set
        {
            sliding = value;

            OnSlide.Invoke(this.timestamps[this.slideIndex]);
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        slidingBackground.OnSlidingBackgroundClick += new SlidingBackground.SlidingBackgroundClickEvent(OnSlidingBackgroundClick);
        int i = 0;
        foreach (var timestamp in timestamps)
        {
            timestamp.gameObject.SetActive(false);
            timestamp.index = i;
            i++;
        }

        //this.EnableTimestamp(1);
        //this.EnableTimestamp(2);
        //this.EnableTimestamp(4);
        this.EnableTimestamp(0);
        //this.EnableTimestamp(3);
        //this.EnableTimestamp(5);

        this.SlideToTimestamp(0);
        //this.SlideToTimestamp(3);
        //this.SlideToTimestamp(1);
        this.doneIntro = true;
    }

    public Timestamp getCurrentTimestamp()
    {
        return this.timestamps[slideIndex];
    }

    private void OnSlidingBackgroundClick(Vector2 position)
    {
        SlideToTimestamp(GetClosestTimestampToPosition(position));
    }

    private int GetClosestTimestampToPosition(Vector2 position)
    {

        var min_diff = new Vector2(float.MaxValue, float.MaxValue);
        int index = 0;
        int result_index = 0;

        foreach (var timestamp in timestamps)
        {
            if (timestamp.rectTransform == null)
            {
                return 1;
            }
            
            if (timestamp.gameObject.activeInHierarchy == false)
            {
                continue;
            }

            var diff = new Vector2(timestamp.rectTransform.position.x, timestamp.rectTransform.position.y) - position;
            if(diff.magnitude <= min_diff.magnitude)
            {
                min_diff = diff;
                result_index = index;
            }

            index++;
        }

        return result_index;
    }

    public void Update()
    {
        if(waitTime <= 0 && !slid)
        {
            this.SlideToTimestamp(0);
            slid = true;
            PlayerSingleton.Instance.CanPlayerMove = true;
            return;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }

        if(!Sliding)
        {
            return;
        }

        if(slideIndex >= timestamps.Length || slideIndex < 0)
        {
            return;
        }

        handleRect.anchorMin = Vector2.Lerp(handleRect.anchorMin, new Vector2(timestamps[slideIndex].rectTransform.anchorMin.x, handleRect.anchorMin.y), 0.01f);
        handleRect.anchorMax = Vector2.Lerp(handleRect.anchorMax, new Vector2(timestamps[slideIndex].rectTransform.anchorMax.x, handleRect.anchorMax.y), 0.01f);
    }

    public void SlideToTimestamp(int index)
    {
        if(this.doneIntro)
        {
            if (this.getCurrentTimestamp() == this.timestamps[index])
            {
                return;
            }
        }
        if (PlayerSingleton.Instance.occupied) return;
        OnStartSlide?.Invoke(this.timestamps[this.slideIndex]);
        StartCoroutine(waitForEnimation(index));
    }

    private IEnumerator waitForEnimation(int index)
    {
        yield return new WaitForSecondsRealtime(0.20f);
        slideIndex = index;
        Sliding = true;
    }

    public void EnableTimestamp(int index)
    {
        this.timestamps[index].gameObject.SetActive(true);
        this.timestamps[index].PlayAnimation();
    }
}