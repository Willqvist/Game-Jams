using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DialogueAudio : MonoBehaviour
{

    public AudioSource hmm1, hmm2, hmm3, hmm4;
    
    private AudioSource[] maleSource;
    private AudioSource[] babySource;
    
    public AudioSource hmm_baby_1, hmm_baby_2;
    // Start is called before the first frame update
    private static DialogueAudio instance;
    public static DialogueAudio Instance => instance;

    private void Awake()
    {
        instance = this;
        maleSource = new AudioSource[]{hmm1,hmm2,hmm3,hmm4};
        babySource= new AudioSource[]{hmm_baby_1,hmm_baby_2};
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static AudioSource randomMaleSound()
    {
        return instance.maleSource[Random.Range(0, instance.maleSource.Length)];
    }
    
    public static AudioSource randomBabySound()
    {
        return instance.babySource[Random.Range(0, instance.babySource.Length)];
    }
    
    public static AudioSource nullAudio()
    {
        return null;
    }
}
