using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignDialogue : Dialogue
{
    protected override async void dialogue()
    {
        this.setAudioProvider(DialogueAudio.nullAudio);
        await this.showContinue("The Blacksmith Factory operate by using the water from the local lake, due to an increase number of squirrels the blacksmith had to shutdown.");
        await this.showContinue("Thanks to all our supporters for our family business between 1900 - <b>1990</b> \n\n\n\n\n //Uncle Joe");
        SmoothSlider.Instance.EnableTimestamp(2);
        end();
    }
}
