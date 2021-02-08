using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookiDialog : Dialogue
{

    public ItemData cobweb;
    private static bool hasGottenString = false;
    protected override async void dialogue()
    {
        this.setAudioProvider(DialogueAudio.nullAudio);
        if (PlayerSingleton.Instance.hasTalkedToBlixtenAfterRats && !hasGottenString)
        {
            await this.showContinue("Cobweb","This looks like something sticky and stringy.");
            hasGottenString = true;
            PlayerSingleton.Instance.CurrentEquippedItem = cobweb;
            this.gameObject.GetComponent<InteractorShower>().disable();
            this.gameObject.SetActive(false);
            end();
            return;
        }

        await this.showContinue("Cobweb","Spooki");
        end();
    }
}
