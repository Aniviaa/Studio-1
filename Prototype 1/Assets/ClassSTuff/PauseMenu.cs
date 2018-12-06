using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : state
{

    public state mainMenu;
    public state gameMenu;

    public override void UpdateScreen(ScreenManager screenM)
    {
        base.UpdateScreen(screenM);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            screenM.ChangeScreen(mainMenu);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            screenM.ChangeScreen(gameMenu);
        }
    }
}
