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

	//A script to limit the movement of the player to their specified camera.
	private CameraMovementLimits _camMoveLimits;

	private Camera _cameraOne; //Camera for Player One.
	private Camera _cameraTwo; //Camera for Player Two.

	[HideInInspector] 
	public int dogNr;

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

	void Awake()
	{
//		_cameraOne = GameObject.Find("Camera Player One").GetComponent<Camera>();
//		_cameraTwo = GameObject.Find("Camera Player Two").GetComponent<Camera>();
		//_camMoveLimits.GetComponent<CameraMovementLimits>();

		_rigid2D = GetComponent<Rigidbody2D>(); //Get Rigidbody2D Component.
		SetKeyCodes(); //Set The Keycodes from the Awakening.
		//SetPlayerCamera(); //Set The Player's specified Camera.
	}

	void Update()
	{
		Movement();

		//Get The Clamped Movement within the screen borders.
		_camMoveLimits.ClampedMovement();
	}

	/// <summary>
	/// Uses the _controlLeft and _controlRight keycodes to move the player.
	/// </summary>
	void Movement()
	{
		if(Input.GetKey(_controlLeft))
		{
			_rigid2D.AddForce(new Vector2(-_movingForce, 0)); //Add Force towards Left Side.
			//transform.Translate(new Vector2(-_movingForce * Time.deltaTime, 0));

			//TODO: Do Animations.
			//TODO: Flip Sprites to Right.
		}

		if(Input.GetKey(_controlRight))
		{
			_rigid2D.AddForce(new Vector2(_movingForce, 0)); //Add Force towards Right Side.
			//transform.Translate(new Vector2(_movingForce * Time.deltaTime, 0));

			//TODO: Do Animations.
			//TODO: Flip Sprites to Left.
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

			dogNr = 1;
		}
		else if(playerNr == PlayerNumber.PlayerTwo) //if Player is Two.
		{
			_controlLeft = _playerTwoControlLeft;
			_controlRight = _playerTwoControlRight;

			dogNr = 2;
		}
	}

//	public void SetPlayerCamera()
//	{
//
//		if(playerNr == PlayerNumber.PlayerOne) //if Player is One.
//		{
//			_camMoveLimits.playerCamera = _cameraOne;
//		}
//		else if(playerNr == PlayerNumber.PlayerTwo) //if Player is Two.
//		{
//			_camMoveLimits.playerCamera = _cameraTwo;
//		}
//	}

}