using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlixtenDialogue : Dialogue
{

    public ItemData cat;

    public AudioSource hiss, meow;
    // Start is called before the first frame update
    protected override async void dialogue()
    {
        if (PlayerSingleton.Instance.GetCurrentEquippedItemType() == ItemType.COBWEB)
        {
            await this.showContinue(meow,"Meow");
            PlayerSingleton.Instance.CurrentEquippedItem = PlayerSingleton.Instance.emptyItem;
            PlayerSingleton.Instance.CurrentEquippedItem = cat;
            this.GetComponent<InteractorShower>().disable();
            this.gameObject.SetActive(false);
            QuestHelper.Instance.SetText("Find something to remove the rats.");
            end();
            return;
        }

        if (PlayerSingleton.Instance.talkedToRats)
        {
            await this.showContinue(hiss,"Hiss");
            QuestHelper.Instance.SetText("Find a way to befriend Blixten");
            PlayerSingleton.Instance.hasTalkedToBlixtenAfterRats = true;
            end();
            return;
        }

        await this.showContinue(hiss,"Hiss");
        end();
        return;
    }
}
