using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WisemanYoung : Dialogue
{
    protected override async void dialogue()
    {
        await this.showContinue("Oh you found me, as you can see, this is right before the apocalypse occured, but since you've found the timeline with the source");
        await this.showContinue("of the apocalypse, must mean that you know the code to the nuclear bomb, right?");
        await this.showContinue("You've been through all those timelines, collected data from all my relatives, you surely have pieced togheter everything by now, right?");
        await this.showContinue("Oh you haven't..? Well that's okay... you can revisit the other timelines to piece it all togheter, when you have the code, insert it into the bomb");

        end();
    }
}
