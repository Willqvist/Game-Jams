using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelEatNutScaredScript : MonoBehaviour
{
    public Transform pointToRunTo;
    public GameObject nutToSpawn;
    public GameObject nutInHandToDissapear;
    public float speed = 1f;
    public AudioSource rustle;
    private bool run;
    private float runScaler = 1f;
    private float originalJumpInterval;
    private float originalJumpHeight;
    private bool finishedRunning = false;

    private void Start()
    {
        this.originalJumpInterval = this.GetComponent<Squirrel>().jumpInterval;
        this.originalJumpHeight = this.GetComponent<Squirrel>().jumpHeight;
    }

    void Update()
    {
        var distance = Vector3.Distance(PlayerSingleton.Instance.gameObjectInstance.transform.position, this.transform.position);
        if(distance <= 1)
        {
            if(run == false)
            {
                run = true;
                rustle.Play();
                this.GetComponent<Squirrel>().startJumpInterval = 0.01f;
                this.GetComponent<Squirrel>().jumpInterval = 0.01f;
                this.GetComponent<Squirrel>().jumpHeight = 0.025f;

                if(this.nutToSpawn != null)
                {
                    GameObject go = DropHelper.Drop(this.nutToSpawn);
                    go.transform.position = this.transform.position;
                    go.transform.localScale = new Vector3(3, 3, 3);
                }
                if(this.nutInHandToDissapear != null)
                {
                    this.nutInHandToDissapear.SetActive(false);
                }
            }
        }

        if(run)
        {
            transform.position += (pointToRunTo.position - transform.position).normalized * speed * runScaler * Time.deltaTime;//Vector3.Lerp(transform.position, pointToRunTo.position, 0.2f);
           
            if(runScaler > 0.3f)
                runScaler -= 1.4f * Time.deltaTime;

            if(Vector3.Distance(this.transform.position, pointToRunTo.transform.position) <= 0.02f)
            {
                this.GetComponent<Squirrel>().startJumpInterval = this.originalJumpInterval;
                this.GetComponent<Squirrel>().jumpHeight = this.originalJumpHeight;
                this.run = false;
                finishedRunning = true;
            }
        }
    }
}
