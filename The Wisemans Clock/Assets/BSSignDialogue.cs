using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSSignDialogue : Dialogue
{
    protected override async void dialogue()
    {
        this.setAudioProvider(DialogueAudio.nullAudio);
        await this.showContinue("Go through the forest to get to the blacks... (The rest has rotted away)");
        end();
    }
}