using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerMotor : MonoBehaviour {

	public float _Speed = 1;

	[SerializeField]
	Text healthText;

	[SerializeField]
	private Vector2 _LastDirection;
	private Vector2 _DeltaForce;
	private Rigidbody2D _RGB;
	private Animator _Anim;

	private BoxCollider2D _BoxCollider;
	private bool _IsMoving;
	public Animator animAttackDown;

	public bool canMove;

	void Awake(){
		_Anim = GetComponent<Animator>();


		_RGB = GetComponent<Rigidbody2D>();
		_BoxCollider = GetComponent<BoxCollider2D>();
	}

	void Start () {
		_RGB.gravityScale = 0;
		_RGB.constraints = RigidbodyConstraints2D.FreezeRotation;

		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (!canMove) {
			_RGB.velocity = Vector2.zero;
			return;
		}

		if (healthText.text.Equals ("0 %")) {
			
		} else {
			CheckInput();
		}
	}

	/// <summary>
	/// Checks the input.
	/// </summary>
	void CheckInput(){
		_IsMoving = false;

		var _H = Input.GetAxisRaw("Horizontal");
		var _V = Input.GetAxisRaw("Vertical");

		if(_H < 0 || _H > 0 || _V < 0 || _V > 0) {

			_IsMoving = true;

			if(!_BoxCollider.IsTouchingLayers(Physics2D.AllLayers))
				_LastDirection = _RGB.velocity;
		}


		_DeltaForce = new Vector2(_H, _V);

		CalculateMovement(_DeltaForce * _Speed);

		/*for (int i = 0; i < _Anim.layerCount; i++)
		{
			
			if (_Anim.GetLayerName(i) == "CharacterController.Idle Blend Tree")
			{
				AnimatorStateInfo stateInfo = _Anim.GetCurrentAnimatorStateInfo(i);

				if (stateInfo.IsName("Idle Blend Tree.CharacterIdleDown"))
				{
					Debug.Log("shouting");
				}
			}
		}*/

		/*
		if (this._Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle Blend Tree.CharacterIdleDown"))
		{
			if (Input.GetKey ("b")) {
				_Anim.Play ("AttackDown");
			}
		}
*/


	}
		
	/// <summary>
	/// Calculates the movement.
	/// </summary>
	/// <param name="PlayerForce">Player force.</param>
	void CalculateMovement(Vector2 PlayerForce){
		_RGB.velocity = Vector2.zero;
		_RGB.AddForce (PlayerForce,ForceMode2D.Impulse);
		SendAnimInfo();
	}

	/// <summary>
	/// Sends the animation info.
	/// </summary>
	void SendAnimInfo(){


		_Anim.SetFloat("XSpeed",_RGB.velocity.x);
		_Anim.SetFloat("YSpeed",_RGB.velocity.y);

		_Anim.SetFloat("LastX",_LastDirection.x);
		_Anim.SetFloat("LastY",_LastDirection.y);

		_Anim.SetBool("IsMoving", _IsMoving);
		/*if(Input.GetKeyDown ("b")){
			_Anim.Play ("Attack Blend Tree");
		}*/
		if (Input.GetKey ("b")) {
			_Anim.SetTrigger ("Trigger");
		}

		if (Input.GetKey ("z")) {
			_Anim.SetTrigger ("TriggerDead");
		}
	}

}
