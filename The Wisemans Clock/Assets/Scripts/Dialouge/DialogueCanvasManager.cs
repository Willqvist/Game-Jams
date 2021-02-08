using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCanvasManager : MonoBehaviour
{
    
    public YesNoDialogueBox yesNoPrefab;
    public ContinueDialogueBox continuePrefab;

    private YesNoDialogueBox yesNoInstance;
    private string activeNpcName = "";
    public static DialogueCanvasManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void setActiveNpcName(string name)
    {
        this.activeNpcName = name;
    }

    private void Start()
    {
        yesNoPrefab.setup();
        continuePrefab.setup();
    }

    public YesNoDialogueBox getYesNo()
    {
        return yesNoPrefab;
    }
    
    public ContinueDialogueBox getContinue()
    {
        return continuePrefab;
    }

    public string getActiveNpcName()
    {
        return this.activeNpcName;
    }


}
