using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour {

	public string dialogue;
	private DialogueManager dMan;

	public string[] dialogueLines;
	bool muestraDialogo=true;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.name == "Player" && muestraDialogo) {
			
			if (Input.GetKeyUp(KeyCode.Space)) {
				//dMan.ShowBox (dialogue);
				muestraDialogo = false;
				if (!dMan.dialogActive) {
					dMan.dialogLines = dialogueLines;
					dMan.currentLine = 0;
					dMan.ShowDialogue();
				}

				if (transform.parent.GetComponent<VillagerMovement>() != null) {
					transform.parent.GetComponent<VillagerMovement>().canMove = false;
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		muestraDialogo = true;
	}

}
