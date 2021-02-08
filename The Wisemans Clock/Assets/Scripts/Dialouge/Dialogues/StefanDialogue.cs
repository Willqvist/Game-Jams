using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class StefanDialogue : Dialogue
{

    private bool hasTalkedAboutNumbers = false;
    
    public NpcDialogue babyDialogue;

    public SceneFadeEnabler stefanHouse;

    public Transform transportTo;

    public Transform newParent;
    
    private bool insideHouse = false;
    
    public static bool teleporting_to_time_baby;
    
    protected override async void dialogue()
    {
        if(GlobalVariables.BrokeSquirrleDam)
        {
            if (hasTalkedAboutNumbers)
            {
                if (PlayerSingleton.Instance.hasTalkedToBlixtenAfterRats)
                {
                    await this.showContinue("How do you befriend the cat? Well he ain't easy to please. But if you find him a toy, he will love you forever.");
                    await this.showContinue("He likes to play with strings. Especially if they are a little bit sticky.");
                    end();
                    return;   
                }

                await this.showContinue("Thanks again for the help. Now i can finally enjoy the lake water.");
                end();
                return;
            }

            if (insideHouse)
            {
                if(teleporting_to_time_baby)
                {
                    end();
                    return;
                }
                await this.showContinue("It ain't much but it's honest work.");
                await this.showContinue("The weird color on the wall? Ye I don't have time to fix that. It was from the old owner.");
                await this.showContinue("There was an old man living in this house before i moved in. The realtor said he was a former engineer at Ekorre Inc.");
                await this.showContinue(
                    "When i moved in there were a bunch of weird number and equations on the wall. All i remembered is that there was a big <b>4</b> in the middle of the wall...");
                await this.showContinue(
                    "There was also an equation beside it. From what i remember it started with 2x*2... but the rest i cant remember. Maybe it was important or something. I dont know, i'm just a farmer.");
                disabled = true;
                hasTalkedAboutNumbers = true;
                PlayerSingleton.Instance.hasTalkedToStefanInsideHouse = true;
                teleporting_to_time_baby = true;
                BabyTransition.Instance.Transition();
                end();
                await Task.Delay(2000);
                babyDialogue.onDialogueBegin();
                disabled = false;
                return;
            }
            QuestHelper.Instance.SetText("");
            await this.showContinue("You got rid of the squirrel dam? Thank you so much!");
            await this.showContinue("Let me invite you into my house!"); 
            SmoothSlider.Instance.gameObject.transform.parent.gameObject.SetActive(false);
            insideHouse = true;
            end();
            this.transform.parent = newParent;
            this.transform.position = transportTo.position;
            stefanHouse.fade(null);
            return;
        }

        if(GlobalVariables.HelpStefan)
        {
            await this.showContinue("There must be a way to break the squirrels dam...");
            end();
            return;
        }

        await this.showContinue("Wait where did you come from! Eh whatever, we have bigger problems on our hands");
        await this.showContinue("You see, there are SQUIRRELS who block our water supply so that trees can't grow, they act like beavers for some reason");
        await this.showContinue("In the past we used to have a blacksmith here, I wish it was still around.. they had tools that would let us deal with these situations");
        //await this.showContinue("Could you have a look around to see if you can find a way to break the blockage? I've heard the blacksmith has some tools");
        //await this.showContinue("Wait a sec where did you come from! Eh whatever we don't have time with that. \n\nI don't know who you are but I've been living here alone for 10 years and I've been needing assistance for quite a while");
        //await this.showContinue("You see, we've had a running problem here with SQUIRRLES. \n\nThey block our dams like beavers for some reason and make our water stop flowing");
        //await this.showContinue("Will you be kind to let me know if you find out a way to deal with them?");
        QuestHelper.Instance.SetText("Find a way to deal with the squirrels for Stefan");
        GlobalVariables.HelpStefan = true;
        end();
    }
}
