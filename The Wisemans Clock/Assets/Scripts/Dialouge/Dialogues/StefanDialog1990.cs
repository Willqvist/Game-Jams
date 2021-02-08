using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StefanDialog1990 : Dialogue
{
    protected override async void dialogue()
    {
        await this.showContinue("wew");
        end();
    }
}
