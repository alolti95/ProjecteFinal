using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	public float totalHP;
	public float currentHP;

	// Use this for initialization
	void Start () {
		currentHP = totalHP;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetMouseButtonDown (0)) {
			TakeDamage();
		}*/
	}

	public void TakeDamage(int dany){
		if (currentHP == 0) {
		} else {
			currentHP -= dany;
			transform.localScale = new Vector3 ((currentHP / totalHP), 1, 1);
		}
	}
}
