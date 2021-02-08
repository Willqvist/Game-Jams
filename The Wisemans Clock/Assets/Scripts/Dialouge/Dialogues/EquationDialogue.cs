using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationDialogue : Dialogue
{
    protected override async void dialogue()
    {
        this.setAudioProvider(DialogueAudio.nullAudio);
        await this.showContinue("2x+2y=... (it was erased)");
        end();
    }
}
