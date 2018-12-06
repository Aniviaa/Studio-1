using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : state
{

    public state pauseMenu;

    public override void UpdateScreen(ScreenManager screenM)
    {
        base.UpdateScreen(screenM);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            screenM.ChangeScreen(pauseMenu);
        }

    }
}
