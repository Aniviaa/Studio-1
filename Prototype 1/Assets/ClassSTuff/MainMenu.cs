using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : state
{

    public state gamePlay;
    public state Options;

    public override void UpdateScreen(ScreenManager screenM)
    {
        //base.UpdateScreen(screenM);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            screenM.ChangeScreen(gamePlay);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            screenM.ChangeScreen(Options);
        }
    }
}
