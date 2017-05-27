using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public string mainMenu;
	public string reset;
	public bool isPaused;
	public GameObject MenuPausaCanvas;
	public GameObject MenuGoCanvas;

	public void menuAction(string Mazmorra)
	{
		Application.LoadLevel(Mazmorra);
	}

	void Update(){
		if (isPaused) {
			Time.timeScale = 0f;           
			MenuPausaCanvas.SetActive (true);
		} else {
			Time.timeScale = 1f;           
			MenuPausaCanvas.SetActive(false);
		}
		if (MenuGoCanvas.activeSelf==true) {
			
		} else {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				isPaused = !isPaused;
			}
		}
	}

	public void Resume(){
		isPaused = false;
	}

	public void Reset(){
		Application.LoadLevel(reset);
	}

	public void MainMenu(){
		Application.LoadLevel(mainMenu);
	}
}

