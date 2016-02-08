using UnityEngine;
using System.Collections;

public enum PlayerNumber
{
	PlayerOne, 
	PlayerTwo
}

public class DogMovement : MonoBehaviour {

	//An Enumerator to select what player number this gameObject is.
	public PlayerNumber playerNr;

	//Rigidbody 2D.
	private Rigidbody2D _rigid2D;

	//Empty Keycodes
	private KeyCode _controlLeft;
	private KeyCode _controlRight;

	//Keycodes for player number one.
	private KeyCode _playerOneControlLeft = KeyCode.A;
	private KeyCode _playerOneControlRight = KeyCode.D;

	//Keycodes for player number two.
	private KeyCode _playerTwoControlLeft = KeyCode.LeftArrow;
	private KeyCode _playerTwoControlRight = KeyCode.RightArrow;

	private float _movingForce = 6f;

	private bool _walking;
	private bool _facingRight;

	Animator[] _dogPartsAnims;

	Animator _dogHeadAnim;
	Animator _dogBodyAnim;


	void Awake()
	{
		_dogPartsAnims = GetComponentsInChildren<Animator>();

		_dogHeadAnim = _dogPartsAnims[0].GetComponentInChildren<Animator>();
		_dogBodyAnim = _dogPartsAnims[1].GetComponentInChildren<Animator>();

		_rigid2D = GetComponent<Rigidbody2D>(); //Get Rigidbody2D Component.
		SetKeyCodes(); //Set The Keycodes from the Awakening.
	}

	void Update()
	{
		Movement();
	}

	/// <summary>
	/// Uses the _controlLeft and _controlRight keycodes to move the player.
	/// </summary>
	void Movement()
	{
		if(Input.GetKey(_controlLeft))
		{
			_walking = true;

			_rigid2D.AddForce(new Vector2(-_movingForce, 0)); //Add Force towards Left Side.

			//Do Animations.
			Animations();

			//Flip Sprite to Left.
			if(_facingRight)
				FlipSprite();
		}

		if(Input.GetKey(_controlRight))
		{
			_walking = true;

			_rigid2D.AddForce(new Vector2(_movingForce, 0)); //Add Force towards Right Side.

			//Do Animations.
			Animations();

			//Flip Sprite to Right.
			if(!_facingRight)
				FlipSprite();
		}
	}

	/// <summary>
	/// Sets the key codes according to the player number.
	/// </summary>
	public void SetKeyCodes()
	{
		if(playerNr == PlayerNumber.PlayerOne) //if Player is One.
		{
			_controlLeft = _playerOneControlLeft;
			_controlRight = _playerOneControlRight;

			_facingRight = true;
		}
		else if(playerNr == PlayerNumber.PlayerTwo) //if Player is Two.
		{
			_controlLeft = _playerTwoControlLeft;
			_controlRight = _playerTwoControlRight;

			_facingRight = false;
		}
	}

	private void Animations()
	{
		if(_walking)
		{
			_dogBodyAnim.SetTrigger("Go_Walk");
			_dogHeadAnim.SetTrigger("Go_Walk");
		}
		else
		{
			_dogBodyAnim.SetTrigger("Go_Idle");
			_dogHeadAnim.SetTrigger("Go_Idle");
		}
	}

	private void FlipSprite()
	{
		_facingRight = !_facingRight;

		Vector2 spriteScale = transform.localScale;
		spriteScale.x *= -1;
		transform.localScale = spriteScale;
	}

}