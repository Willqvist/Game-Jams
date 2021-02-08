using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverDialogue : Dialogue
{

    public RiverOpenScript openenerAnimator;
    public InteractorShower shower;
    public ItemData saw;
    protected override void onStart()
    {
        base.onStart();
        //PlayerSingleton.Instance.CurrentEquippedItem = saw;
    }

    protected override async void dialogue()
    {
        this.setAudioProvider(DialogueAudio.nullAudio);
        var type = PlayerSingleton.Instance.GetCurrentEquippedItemType();
        if (type == ItemType.EMPTY)
        {
            await this.showContinue("Hmm, i need a tool to fix this blockage...");
        }
        else if(type == ItemType.NUT)
        {
            await this.showContinue("Hmm, this nut wont work. are you nuts?");
        }
        else if(type == ItemType.SAW)
        {
            //await this.showContinue("This item should work...");
            openenerAnimator.startAnimation();
            shower.disable();
            //GetComponent<AudioSource>().Play();
            GlobalVariables.IsBridgeBroken = true;
            PlayerSingleton.Instance.dropCurrentItem();
        }
        else
        {
            await this.showContinue("This item wont work...");
        }

        end();
    }
}
