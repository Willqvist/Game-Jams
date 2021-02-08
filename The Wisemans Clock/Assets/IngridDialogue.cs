using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngridDialogue : Dialogue
{
    protected override async void dialogue()
    {
        this.setAudioProvider(DialogueAudio.randomBabySound);
        await this.showContinue("Hi there. I'm Ingrid, welcome to our little village.");
        await this.showContinue("We have been living here for 5 years and we love it!");
        await this.showContinue("We have been trying to start a family, but no luck there.");
        await this.showContinue("Anyways, nice to meet you!");
        end();
    }
}
