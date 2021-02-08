using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderContainer : MonoBehaviour
{
    public TimestampText timestampText;

    private void Start()
    {
        SmoothSlider.OnSlide += new SmoothSlider.SlideEvent(timestampText.onSmoothSliderSlide);
    }
}
