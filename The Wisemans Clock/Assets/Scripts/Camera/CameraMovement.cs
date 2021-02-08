using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform follow;
    public float smooth = 1;
    private Vector3 pos = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.Set(Mathf.Lerp(pos.x,follow.position.x, smooth*Time.deltaTime),pos.y,pos.z);
        transform.position = pos;
        //transform.LookAt(follow, Vector3.up);
    }
}
