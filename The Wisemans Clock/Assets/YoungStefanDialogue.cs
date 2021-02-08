using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoungStefanDialogue : Dialogue
{
    protected override async void dialogue()
    {
        await this.showContinue("Hello there. ");
        await this.showContinue("Have you met my wife Ingrid? She is lovely. I bet you would also love her. But she is taken already so dont fall in love to much. HOHOHO");
        await this.showContinue("Enjoy your stay in out little village.");
        end();
    }
}
