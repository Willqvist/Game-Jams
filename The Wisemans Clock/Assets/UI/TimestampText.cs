using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimestampText : TextMeshProUGUI
{
    private bool lerp;
    private float from;
    private float to;

    public void onSmoothSliderSlide(Timestamp timestamp)
    {
        int result;
        float resultf;

        lerp = true;
        if(int.TryParse(this.text, out result))
        {
            this.from = result;
          
        }
        else
        {
            lerp = false;
        }

        if(float.TryParse(timestamp.timestamp, out resultf))
        {
            this.to = resultf;
        }
        else
        {
            lerp = false;
        }
        
        if(int.TryParse(timestamp.timestamp, out result))
        {
            TimestampSingleton.Instance.currentTime = result;
        }
        else
        {
            lerp = false;
        }

        if(!lerp)
        {
            this.text = timestamp.timestamp;
        }
    }

    private void Update()
    {
        if(!lerp)
        {
            return;
        }

        this.from = Mathf.Lerp(this.from, this.to, 0.01f);
        this.text = Mathf.RoundToInt(this.from).ToString();
    }
}
