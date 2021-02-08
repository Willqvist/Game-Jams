using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncleJoeDialog : Dialogue
{

    private bool hasFoundSquirrel = false;
    
    protected override async void dialogue()
    {
        if (SmoothSlider.Instance.getCurrentTimestamp().timestamp.Equals("1930"))
        {
            await this.showContinue("Hey there chap, how's it hanging, I've never seen you around before, you new? Are you the son of my crazy neighbour? no? okay.");
            await this.showContinue("I'm Uncle Joe, the uncliest uncle in town, haha funny right...");
            await this.showContinue("I thought you were his son because i have not seen the old man in a few days. Last time i was him was with a bunch of people in black suits.");
            await this.showContinue("The day after he was gone and he had written something weird on my wall.");
            await this.showContinue("What was it? Well it was something like <b>x=3^2 - ???</b>. I can't remember the last letter but i remember seeing it in his house when i was there one day.");
            end();
            return;
        }

        if(GlobalVariables.ShouldCollectSquirrelForUncleJoe)
        {
            if(!hasFoundSquirrel && PlayerSingleton.Instance.GetCurrentEquippedItemType() == ItemType.SQUIRRLE)
            {
                await this.showContinue("Yaaay a furry friend! Thank you so much kind stranger");
                await this.showContinue("Oh right you needed a saw right? There is one in the back");
                PlayerSingleton.Instance.CurrentEquippedItem = PlayerSingleton.Instance.emptyItem;

                var go = DropHelper.Drop(ObjectSpawnHelper.Instance.saw);
                go.transform.position = SawSpawnLocationUncleJoeQuest.Instance.transform.position;

                var go2 = DropHelper.Drop(ObjectSpawnHelper.Instance.squirrle);
                go2.transform.position = EkorrSpawnlocationUncleJoeQuest.Instance.transform.position;

                QuestHelper.Instance.SetText("Find a way to deal with the squirrels for Stefan");
                hasFoundSquirrel = true;
                end();
                return;
            }
            else
            {
                if (hasFoundSquirrel)
                {
                    await this.showContinue("Thanks for the squirrel. The saw is in the back.");
                }
                else
                {
                    await this.showContinue("Have you found a furry friend for me?");
                }

                end();
                return;
            }
        }

        await this.showContinue("Hey there chap, how's it hanging, I've never seen you around before, you new?");
        await this.showContinue("I'm Uncle Joe, the uncliest uncle in town, haha funny right...");
        await this.showContinue("Oh you're in need of tools? For a squirrel dam? You realise that squirrels don't make dams right haha");
        await this.showContinue("Fine, I guess, whatever, maybe we can make an arrangement, you know, I live in these forests because I love squirrels");
        await this.showContinue("I've always wanted a pet, because I don't really have anyone around me like my brother Stefan and my nephew Bob, they're so far away...");
        await this.showContinue("They also find me pretty annoying with all my uncle jokes... so they don't really want to be around");
        await this.showContinue("Maybe if you get me a pet I can help you out with the tools for your 'squirrle dam' or whatever haha");

        /*
        await this.showContinue("Hey there chap, how's it hanging?");
        await this.showContinue("I've never seen you around here before? Are you new?");
        await this.showContinue("Ah I see, well, let me introduce myself.......... by telling a story");
        await this.showContinue("I'm Joe, but people call me uncle joe becuase I'm the uncliest uncle out there, funny right haha?");
        await this.showContinue("Yea I've been runnin this ol' blacksmith for yeaaaaaaaaaaaaaaaaaars");
        await this.showContinue("It's powered by using water from the nearby lake you know hohoho if something went wrong with that I would be in a heap of trouble!");
        await this.showContinue("You might be wondering, well, how the water powers the blacksmith");
        await this.showContinue("Well in all honesty, I don't really know, all I know is that uncle joe gets some water from down the lake");
        await this.showContinue("And put that water in this machine here, you know.. because that makes sense... I think? Does it? I never really question my reality");
        await this.showContinue("I'm just a generic ol' chap you know, tryna make my way through life");
        await this.showContinue("Anyways, long story short, water + blacksmith = tools and happy people :-)");

        await this.showContinue("You're probably eager to hear about my accomplishments in life! People usually enjoy listening to me speaking about myself, because you know, I'm the uncliest uncle");
        await this.showContinue("I grew up in this small village, been livin' here for my entire life");
        await this.showContinue("This blacksmith used to be my father's, he created this blacksmith with a clear goal, a goal to bring this village the tools they need!");
        await this.showContinue("My father named me Joe because he wanted me to be as generic as possible, I didn't really understand what he meant but I take it as a compliment!");
        await this.showContinue("Anyways you might be wondering what I've been doing with my life, well, I've won several awards for the best blacksmith in the world!");
        await this.showContinue("And I was the only one nominated! And I even created the competition myself! That's quite some dedication aint it chap?");
        await this.showContinue("Anyways what's your name? Aaaaaaaaaaa who am I kidding who cares about your name am I right people are just here for uncle joe");
        await this.showContinue("Yea so where was I... Ah right, yea as you see I am the greatest man this village ever seen");
        await this.showContinue("People from around here, aren't always that nice to ol' uncle joe you know");

        await this.showContinue("They, you know, usually call me a big talker, but I don't really understand why");
        await this.showContinue("I dont feel like I talk a lot, do you? I just like talking about my interests, but for some reason people never speak back to me");
        await this.showContinue("It's like.. it's like talking to a brick wall you know? Feels like people never listen on ol' uncle joe you know? You just want to tell your stories");
        await this.showContinue("And they just never respond you know? Ugh... my life is terrible sometimes... poor me :(");
        await this.showContinue("Oh you're still here? You haven't said anything in a while.. anyways.. you know.. my favourite animal is a <b>squirrel</b>");
        await this.showContinue("That's why I live around these areas you know, because I like the animals so much...");
        await this.showContinue("Could you be friendly and maybe help uncle joe out?");
        await this.showContinue("I'm feeling so down, I feel like I need a cuddle friend, could you get something for me to cuddle with? :(");
        */
        QuestHelper.Instance.SetText("Cheer Uncle Joe up by finding him a cuddle friend");
        GlobalVariables.ShouldCollectSquirrelForUncleJoe = true;
        end();
    }
}
