using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverOpenScript : MonoBehaviour
{
    public Animator riverAnimator;
    public Animator stoneAnimator;
    public AudioSource audio;
    public AudioSource water;
    public void startAnimation()
    {
        riverAnimator.SetBool("start",true);
        stoneAnimator.SetBool("start",true);
        audio.Play();
        water.volume = 0.2f;
        GlobalVariables.BrokeSquirrleDam = true;
    }
}
