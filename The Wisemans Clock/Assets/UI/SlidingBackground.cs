using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlidingBackground : MonoBehaviour, IPointerClickHandler
{
    public delegate void SlidingBackgroundClickEvent(Vector2 position);
    public event SlidingBackgroundClickEvent OnSlidingBackgroundClick; 

    public void OnPointerClick(PointerEventData eventData)
    {
        OnSlidingBackgroundClick.Invoke(eventData.position);
    }
}
