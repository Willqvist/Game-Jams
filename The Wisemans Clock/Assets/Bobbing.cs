using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{

    private Vector3 orgPos;
    public float bobStrength = 1;
    private float a = 0;

    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        orgPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        a += Time.deltaTime*10;
        this.transform.position.Set(orgPos.x,(float) (orgPos.y+Math.Sin(a)*bobStrength),orgPos.z);
    }
}
