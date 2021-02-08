using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatDialogue : Dialogue
{

    public Collider entranceCollider;
    public ItemData cat;
    protected override void onStart()
    {
        base.onStart();
    }

    protected override async void dialogue()
    {
        this.setAudioProvider(DialogueAudio.nullAudio);
        var type = PlayerSingleton.Instance.GetCurrentEquippedItemType();
        if (type == ItemType.EMPTY)
        {
            await this.showContinue("The rats are blocking the way. Find a way to remove them.");
            QuestHelper.Instance.SetText("Find something to remove the rats.");
            PlayerSingleton.Instance.talkedToRats = true;
        }
        else if(type == ItemType.CAT)
        {
            QuestHelper.Instance.SetText("");
            this.gameObject.GetComponent<InteractorShower>().disable();
            entranceCollider.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            await this.showContinue("This item wont work...");
        }
        end();
    }
}
