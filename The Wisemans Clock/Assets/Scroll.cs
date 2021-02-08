using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollSpeed = 100f;

    private void Update()
    {
        this.GetComponent<RectTransform>().position += new Vector3(0, scrollSpeed * Time.deltaTime, 0);

        if(this.GetComponent<RectTransform>().position.y >= 7250)
        { 
            Application.Quit();
        }
    }
}
