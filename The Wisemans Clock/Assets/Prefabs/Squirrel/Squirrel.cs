using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    public float jumpHeight;
    public float jumpInterval = 1f;

    [HideInInspector] public float startJumpInterval;
    private float startHeight;
    private bool hasJumpedUp;

    private void Start()
    {
        this.startHeight = this.transform.position.y;
        this.startJumpInterval = this.jumpInterval;
    }

    void Update()
    {
        jumpInterval -= Time.deltaTime;

        if(jumpInterval <= 0)
        {
            if(!hasJumpedUp)
            {
                transform.position = new Vector3(transform.position.x, startHeight + jumpHeight, transform.position.z);
                hasJumpedUp = true;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, startHeight, transform.position.z);
                hasJumpedUp = false;
            }

            jumpInterval = this.startJumpInterval;
        }
    }
}
