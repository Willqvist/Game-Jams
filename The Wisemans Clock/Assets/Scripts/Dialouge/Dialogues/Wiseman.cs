using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiseman : Dialogue
{

    private bool introStated = false;

    protected override void onStart()
    {
        base.onStart();
    }

    protected override async void dialogue()
    {
        //SmoothSlider.Instance.EnableTimestamp(5);
        //SmoothSlider.Instance.EnableTimestamp(4);
        //SmoothSlider.Instance.EnableTimestamp(1);
        //end();
        //return;
        //await this.showContinue("What are you waiting for. Use the clock on the bottom of the screen to travel to different places in time.");
        //BabyTransition.Instance.Transition();
        //Dialogue.forceQuitActiveDialogue();
        //await this.showContinue("What are you waiting for. Use the clock on the bottom of the screen to travel to different places in time.");
        //end();
        //return;
        if (introStated)
        {
            await this.showContinue("What are you waiting for. Use the clock on the bottom of the screen to travel to different places in time.");
        }
        else
        {
            await this.showContinue("Unknown?",
                "A beautiful day isn't it? The warmth from the lava has been warming this place now for many years since the apocalypse began. It has never been cold since.\n\n ");
            
            await this.showContinue("Unknown?",
                "Anyways... I know why you're here my son. You have many unanswered questions. How did this happen? Who created the apocalypse? Who am I?");
            
            await this.showContinue("Unknown?",
                "I go by many names. The old man, the Unknown. But I am most known by...");
            
            await this.showContinue("The <b>Wiseman</b>!");
            
            await this.showContinue(
                "I know why the apocalypse happened, why it happened and when it happened. And I will help you save the world!");
            
            await this.showContinue(
                "You probably wonder how we can stop the apocalypse. I have created a <b>Time machine</b> that will let you <b>rewind</b> time to stop the apocalypse");
            
            await this.showContinue(
                "You have to gather 4 codes from around different times throughout history and give them to me so I can stop <b>Ekorre Inc</b> from sending the nuclear bombs.");
            
            await this.showContinue(
                "The first code can be found at my old friend <b>Stefan</b> that I knew a long time ago. When you meet him, ask him about the weird numbers.");
            
            await this.showContinue("Remember to <b>observe</b> your surroundings and <b>Remember!</b>");
            await this.showContinue("Use the clock on the bottom of the screen to travel to different places in time.");
            introStated = true;
            SmoothSlider.Instance.EnableTimestamp(1);
        }

        end();
    }
}
