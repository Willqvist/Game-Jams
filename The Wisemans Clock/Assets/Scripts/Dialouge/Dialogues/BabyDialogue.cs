using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyDialogue : Dialogue
{
    protected override async void dialogue()
    {
        this.setAudioProvider(DialogueAudio.randomBabySound);
        await this.showContinue("Hi! I'm Bob. Stefan's son. Nice to meet you!");
        await this.showContinue("I'm doing cool tricks with my tricycle down this edge. I can soon do a back flip. But it's dangerous.");
        await this.showContinue("I don't want to break my tricycle because the Blacksmith is not here anymore, so my dad cant get tools.");
        await this.showContinue("I have been trying to find nuts to feed them but no water means no growth on trees. So no more nuts to lure them away.");
        await this.showContinue("Anyways. I most keep practicing to become the new Tony Hawk of tricycle.");
        end();
    }
}
