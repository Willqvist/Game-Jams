using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Babydialog : Dialogue
{
    private bool has_talked = false;

    protected override async void dialogue()
    {
        this.setAudioProvider(DialogueAudio.randomBabySound);
        if(has_talked)
        {
            if (Puzzle_1.Instance.nuts[0].name.StartsWith("s") &&
                Puzzle_1.Instance.nuts[1].name.StartsWith("q") &&
                Puzzle_1.Instance.nuts[2].name.StartsWith("u") &&
                Puzzle_1.Instance.nuts[3].name.StartsWith("i") &&
                Puzzle_1.Instance.nuts[4].name.StartsWith("r") &&
                Puzzle_1.Instance.nuts[5].name.StartsWith("r") &&
                Puzzle_1.Instance.nuts[6].name.StartsWith("e") &&
                Puzzle_1.Instance.nuts[7].name.StartsWith("l"))
            {
                await this.showContinue("You got it right! Goodbye for now");
                end();
                BabyTransition.Instance.GoBackToOldPosition();
                return;
            }
            else
            {
                await this.showContinue("What are you doing? That's not the correct word, you dum dum!");
                end();
                return;
            }
        }

        await this.showContinue("Hello, I am the time baby, you've been summoned to this location because of your abuse of the time powers given");
        await this.showContinue("Therefor, you need to complete my puzzle in order to show your worth, that you are able to keep these powers given");
        await this.showContinue("Rearrange the nuts to form a word, if you rearrange them correctly, come back to me");
        has_talked = true;
        StefanDialogue.teleporting_to_time_baby = false;
        end();
    }
}
