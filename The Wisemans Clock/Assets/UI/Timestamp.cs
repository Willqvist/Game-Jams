using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timestamp : MonoBehaviour
{
    public string timestamp;
    [HideInInspector] public RectTransform rectTransform;
    [HideInInspector] public int index = 0;

    private void Start()
    {
        this.rectTransform = GetComponent<RectTransform>();
    }

    public void PlayAnimation()
    {
        this.GetComponent<Animator>().Play("TimestampButtonAnimation");
    }
}
