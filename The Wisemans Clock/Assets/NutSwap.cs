using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSwap : MonoBehaviour
{
    public int index;

    bool lerping = false;
    private Vector3 lerp_to;

    private void Update()
    {
        if(!lerping)
        {
            return;
        }

        if(Vector3.Distance(transform.position, lerp_to) > 0.001f)
        {
            transform.position = Vector3.Lerp(transform.position, lerp_to, 0.2f);
        }
        else
        {
            lerping = false;
            lerp_to = Vector3.zero;
        }
    }

    public void LerpToPosition(Vector3 v)
    {
        lerp_to = v;
        lerping = true;
    }
}
