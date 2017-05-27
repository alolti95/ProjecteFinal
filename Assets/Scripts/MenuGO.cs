using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGO : MonoBehaviour {

	public string mainMenu;
	public string reset;
	public bool isPaused;
	public GameObject MenuGOCanvas;

	public void menuAction(string Mazmorra)
	{
		Application.LoadLevel(Mazmorra);
	}

	void Update(){
		if (isPaused) {
			Time.timeScale = 0f;           
			MenuGOCanvas.SetActive (true);
		} else {
			Time.timeScale = 1f;           
			MenuGOCanvas.SetActive(false);
		}

	}

	public void Reset(){
		Application.LoadLevel(reset);
	}

	public void Quit(){
		Application.LoadLevel(mainMenu);
	}
}
