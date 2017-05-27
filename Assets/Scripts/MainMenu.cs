using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string loadGame;

	public void NewGame(){
		Application.LoadLevel(startLevel);
	}

	public void LoadGame(){
		Application.LoadLevel(loadGame);
	}

	public void QuitGame(){
		Application.Quit();
	}
}
