using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSSignDialogue : Dialogue
{
    protected override async void dialogue()
    {
        this.setAudioProvider(DialogueAudio.nullAudio);
        await this.showContinue("House for sale. Luxury house, 45 sqm of pure bliss. Interested?\nContact us at\nEkorreRealtor@gkorre.com \n\nFor a better future.\n<b>EkorreRealtor.com</b>");
        end();
    }
}
