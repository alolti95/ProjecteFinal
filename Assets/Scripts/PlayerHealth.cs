using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]
	Slider healthBar;

	[SerializeField]
	Text healthText;

	private Animator _Anim;
	public GameObject MenuGO;
	float maxHealth = 100;
	float currentHealth;

	// Use this for initialization
	void Start () {
		healthBar.value = maxHealth;
		currentHealth = healthBar.value;
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Saw") {
			healthBar.value -= 1f;
			currentHealth = healthBar.value;
		}
		else if (col.gameObject.tag == "Enemy") {
			healthBar.value += 1f;
			currentHealth = healthBar.value;
		}
	}

	// Update is called once per frame
	void Update () {
		_Anim = GetComponent<Animator>();
		healthText.text = currentHealth.ToString() + " %";
		if (currentHealth <= 0) {
			//Destroy (this.gameObject);
			//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			_Anim.SetTrigger ("TriggerDead");
			MenuGO.gameObject.SetActive(true);

		}
	}
}
