using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour {

    public state currentScreen;

	// Replace this with stack
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //thisstack .peek.execute
        currentScreen.UpdateScreen(this);
	}

    public void ChangeScreen(state newState)
    {
        currentScreen.gameObject.SetActive(false);
        currentScreen = newState;
        currentScreen.gameObject.SetActive(true);
        //push everytime you change the currentscreen
    }
}
