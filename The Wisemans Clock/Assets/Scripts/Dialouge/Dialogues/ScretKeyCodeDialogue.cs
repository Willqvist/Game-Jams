using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScretKeyCodeDialogue : Dialogue
{

    public CodeSolver solver;

    private bool showedOpenText = false;
    
    protected override async void dialogue()
    {
        this.setAudioProvider(DialogueAudio.nullAudio);
        if (showedOpenText)
        {
            await this.showContinue("Engineers last note","<b>Ekorre INC</b> is trying to take over the world. The number <b>4</b> on the wall and the value of x=<b>5</b> is important for them and dont want anyone to know about it.");
            await this.showContinue("Engineers last note","There was other numbers that they want to keep a secret. If you want to find them. I once knew a guy living where the Blacksmith is now. I don't know where he is now. ");
            await this.showContinue("Engineers last note","This is my last note, please stop them. Find the other numbers.");

            end();
            return;
        }

        if (PlayerSingleton.Instance.hasSolvedSafe)
        {
            QuestHelper.Instance.SetText("");
            await this.showContinue("Engineers last note","You got it open. Now you will hear about my secrets");
            await this.showContinue("Engineers last note","<b>Ekorre INC</b> is trying to take over the world. The number <b>4</b> on the wall and the value of x=<b>5</b> is important for them and dont want anyone to know about it.");
            await this.showContinue("Engineers last note","There was other numbers that they want to keep a secret. If you want to find them. I once knew a guy living where the blacksmith is now. I don't know where he is now. ");
            await this.showContinue("Engineers last note","They're coming. This is my last note, please stop them. Find the other numbers.");
            end();
            GlobalVariables.HasSolvedSecretChest = true;
            showedOpenText = true;
            
            return;
        }
        

        await this.showContinue("Before i leave this place for good I will leave my most priced possession. To open the safe I need a code, the code is my award winning equation.");
        await this.showContinue("I can help you on your track. y is the year my neighbour moved in. You have to solve x on your own.");
        QuestHelper.Instance.SetText("Find x and y to solve the equation.");
        //CodeSolver.showSolution(123);
        end();
        solver.OnActivate();
    }
}
