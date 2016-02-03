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

	private float _movingForce = 30f;

	void Awake()
	{
		_rigid2D = GetComponent<Rigidbody2D>(); //Get Rigidbody2D Component.
		SetKeyCodes(); //Set The Keycodes from the beginning.
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
			_rigid2D.AddForce(new Vector2(-_movingForce * Time.deltaTime, 0)); //Add Force towards Left Side.
		}

		if(Input.GetKey(_controlRight))
		{
			_rigid2D.AddForce(new Vector2(_movingForce * Time.deltaTime, 0)); //Add Force towards Right Side.
		}
	}

	/// <summary>
	/// Sets the key codes according to the player number.
	/// </summary>
	private void SetKeyCodes()
	{
		if(playerNr == PlayerNumber.PlayerOne) //if Player is One.
		{
			_controlLeft = _playerOneControlLeft;
			_controlRight = _playerOneControlRight;
		}
		else if(playerNr == PlayerNumber.PlayerTwo) //if Player is Two.
		{
			_controlLeft = _playerTwoControlLeft;
			_controlRight = _playerTwoControlRight;
		}
	}

}