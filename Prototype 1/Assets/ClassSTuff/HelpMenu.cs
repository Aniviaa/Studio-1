using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : state
{

    public state optionMenu;

    public override void UpdateScreen(ScreenManager screenM)
    {
        base.UpdateScreen(screenM);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            screenM.ChangeScreen(optionMenu);
        }

    }
}
