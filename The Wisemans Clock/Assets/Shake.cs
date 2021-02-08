using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float shakeSize = 2;

    public float speed = 1;

    private Quaternion orgAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        orgAngle = this.transform.rotation;
    }

    private Quaternion rot;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = orgAngle * Quaternion.Euler(orgAngle.x, orgAngle.y + Mathf.Sin(Time.time * speed * Mathf.Max(0.2f,Random.value))*shakeSize, orgAngle.z);
    }
}
