using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    private YesNoDialogueBox yesNoPrefab;
    private ContinueDialogueBox continuePrefab;
    private Action callbackWhenDone;
    private GameObject activeView;

    private static Dialogue activeDialogue;
    
    private string npcName;

    private Vector3 pos;
    
    protected delegate AudioSource AudioMethod();

    private AudioMethod audioProvider = DialogueAudio.randomMaleSound;

    protected bool disabled = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //yesNoPrefab = DialogueCanvasManager.instance.getYesNo();
        continuePrefab = DialogueCanvasManager.instance.getContinue();
        onStart();
    }
    

    protected virtual void onStart()
    {
    }


    protected void setAudioProvider(AudioMethod method)
    {
        this.audioProvider = method;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void setupDialogue(string npcName, Action action)
    {
        if (disabled)
        {
            action();
            return;
        }

        this.npcName = npcName;
        callbackWhenDone = action;
        PlayerSingleton.Instance.occupied = true;
        activeDialogue = this;
        setAudioProvider(DialogueAudio.randomMaleSound);
        dialogue();
    }

    public static void forceQuitActiveDialogue()
    {
        activeDialogue?.end();
    }

    protected virtual void dialogue() { }

    public void end()
    {
        PlayerSingleton.Instance.occupied = false;
        if(this.activeView != null)
            this.activeView.SetActive(false);
        this.activeView = null;
        activeDialogue = null;
        callbackWhenDone.Invoke();
    }

    protected Task<bool> showYesNo(string msg)
    {
        return null;
        if(activeView != null)
            activeView.SetActive(false);
        activeView = yesNoPrefab.getInstance();
        TaskCompletionSource<bool> tcs1 = new TaskCompletionSource<bool>();
        yesNoPrefab.show(npcName,msg);
        yesNoPrefab.onClick((val) =>
        {
            tcs1.SetResult(val);
        });
        return tcs1.Task;
    }
    protected Task showContinue(string msg)
    {
        return showContinue(audioProvider != null ? audioProvider():DialogueAudio.randomMaleSound(),this.npcName, msg);
    }
    
    protected Task showContinue(AudioSource audio, string msg)
    {
        return showContinue(audio,this.npcName, msg);
    }
    
    protected Task showContinueNoAudio(string msg)
    {
        return showContinue(null,this.npcName, msg);
    }
    protected Task showContinueNoAudio(string name,string msg)
    {
        return showContinue(null,this.npcName, msg);
    }
    protected Task showContinue(string name,string msg)
    {
        return showContinue(audioProvider != null ? audioProvider():DialogueAudio.randomMaleSound(),name, msg);
    }
    
    protected Task showContinue(AudioSource audioSource, string name, string msg)
    {
        if(audioSource != null)
            audioSource.Play();
        TaskCompletionSource<bool> tcs1 = new TaskCompletionSource<bool>();
        if (Dialogue.activeDialogue == null)
        {
            tcs1.SetResult(true);
            return tcs1.Task;
        }

        if(activeView != null)
            activeView.SetActive(false);
        activeView = continuePrefab.getInstance();
        continuePrefab.show(name,msg);

        continuePrefab.onClick(() =>
        {
            tcs1.SetResult(true);
        });
        return tcs1.Task;
    }
}
