using UnityEngine;
using System.Collections;

public class CameraMovementLimits : MonoBehaviour {

	private 	float 		_distance; 			//The distance between the camera's and the player's Z position.
	private 	float 		_leftLimit; 		//The Left Camera Border.
	private 	float 		_rightLimit; 		//The Right Camera Border.

	public 		Camera		playerCamera;		//Player's specified Camera.
	private 	Vector2		_position;			//Player's position vector.

	void Awake()
	{
		_position = transform.position;
		_distance 	= (transform.position.z - Camera.main.transform.position.z);

		_leftLimit 	= playerCamera.ViewportToWorldPoint(new Vector2(0, _distance)).x;
		_rightLimit = playerCamera.ViewportToWorldPoint(new Vector2(1, _distance)).x;
	}

	void Update()
	{
		//ClampedMovement(GetComponent<Transform>());
	}

	public void ClampedMovement()
	{
		float tempX = Mathf.Clamp(_position.x, _rightLimit, _leftLimit);
		_position = new Vector2(tempX, _position.y);

		//_position.x = Mathf.Clamp(_position.x, _rightLimit, _leftLimit);
	}
}