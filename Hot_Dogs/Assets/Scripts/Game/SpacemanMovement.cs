using UnityEngine;
using System.Collections;

public enum SpacemanMovementTypes
{
	Rotating, 
	Moving, 
	MovingAndRotating
}

public class SpacemanMovement : MonoBehaviour {

	public SpacemanMovementTypes spacemanMovementType;

	private Rigidbody2D _rigid2D;

	public float rotationForce = 0.6f;
	public float movingForceX = 1.2f;
	public float movingForceY = 0.3f;

	void Awake()
	{
		_rigid2D = GetComponent<Rigidbody2D>();
	}
		
	void Update()
	{
		TypeSwitch();
	}

	private void TypeSwitch()
	{
		switch(spacemanMovementType)
		{
			case SpacemanMovementTypes.Moving:
				Moving();
				break;
			case SpacemanMovementTypes.Rotating:
				Rotation();
				break;
			case SpacemanMovementTypes.MovingAndRotating:
				MovingAndRotating();
				break;
		}
	}

	private void Rotation()
	{
		float z = rotationForce * Time.deltaTime;

		transform.Rotate(new Vector3(0, 0, -z));
	}

	private void Moving()
	{
		float x = movingForceX * Time.deltaTime;
		float y = movingForceY * Time.deltaTime;

		_rigid2D.AddForce(new Vector2(x, y));
	}

	private void MovingAndRotating()
	{
		float x = movingForceX * Time.deltaTime;
		float y = movingForceY * Time.deltaTime;
		float z = rotationForce * Time.deltaTime;

		_rigid2D.AddRelativeForce(new Vector2(x, y));
		transform.Rotate(new Vector3(0, 0, z));
	}

}
