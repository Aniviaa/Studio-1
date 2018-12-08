using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : state{

    public state helpMenu;
    public state MainMenu;

    public override void UpdateScreen(ScreenManager screenM)
    {
        base.UpdateScreen(screenM);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            screenM.ChangeScreen(MainMenu);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            screenM.ChangeScreen(helpMenu);
        }
    }
}
