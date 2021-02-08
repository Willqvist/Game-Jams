using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperDialogue : Dialogue
{
    protected override async void dialogue()
    {
        this.setAudioProvider(DialogueAudio.nullAudio);
        await this.showContinue("Note 324.3\n\nThe house is rat infested. We need to fix that.");
        await this.showContinue("Anyways... We are almost finished creating the most powerful bomb ever created.");
        await this.showContinue("This bomb (model 1945, v.16jun) will make <b>Ekorre INC</b> The most powerful company in the world. No one would even try to compete, we will just send the bomb to their headquarters. HAHAHA");
        await this.showContinue("Our best engineer that created the best algorithm ever created went crazy so we had to let him go. We used to call him Wiseman because he was wise. And also fascinated by time");
        await this.showContinue("He stole the first two digits of the code to enable the nuke. That bastard. We can't take him in because he is watched by the government. But soon we will be able to buy the government and take him in. We just need 50 more years.");
        await this.showContinue("The last two digits of the code is <b>6</b> and <b>2</b>. And the first two i don't know. \n\n End of Note.");
        PlayerSingleton.Instance.hasTalkedToNukeNote = true;
        end();
    }
}
