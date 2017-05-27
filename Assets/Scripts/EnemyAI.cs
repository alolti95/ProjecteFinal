using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	Transform target;
	Transform enemyTransform;
	public float speed = 3;
	public float rotationSpeed = 3;
	public float detectionRange = 10;

	// Use this for initialization
	void Start () {
		enemyTransform = this.GetComponent<Transform> ();	
	}
	
	// Update is called once per frame
	void Update () {
		target = GameObject.FindWithTag ("Player").transform;
		Vector3 targetHeading = target.position - transform.position;
		Vector3 targetDirection = targetHeading.normalized;

		transform.rotation = Quaternion.LookRotation (targetDirection);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
		enemyTransform.position += enemyTransform.forward * speed * Time.deltaTime;
	}
}


