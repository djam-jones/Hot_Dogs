using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	private GameObject _playerOneCameraTransform;
	private GameObject _playerTwoCameraTransform;

	public float intensity = 0.6f;
	public float shakeTime = 0.0f;

	private float _descreaseFactor = 1.0f;

	private Vector3 _originPositionCameraOne;
	private Vector3 _originPositionCameraTwo;

	void Awake()
	{
		_playerOneCameraTransform = GameObject.Find("Camera Player One");
		_playerTwoCameraTransform = GameObject.Find("Camera Player Two");
	}

	void OnEnable()
	{
		_originPositionCameraOne = _playerOneCameraTransform.transform.localPosition;
		_originPositionCameraTwo = _playerTwoCameraTransform.transform.localPosition;
	}

	void Update()
	{
		if(shakeTime > 0)
		{
			_playerOneCameraTransform.transform.localPosition = _originPositionCameraOne + Random.insideUnitSphere * intensity;
			_playerTwoCameraTransform.transform.localPosition = _originPositionCameraTwo + Random.insideUnitSphere * intensity;

			shakeTime -= Time.deltaTime * _descreaseFactor;
		}
		else
		{
			shakeTime = 0f;
			_playerOneCameraTransform.transform.localPosition = _originPositionCameraOne;
			_playerTwoCameraTransform.transform.localPosition = _originPositionCameraTwo;
		}
	}
		
}