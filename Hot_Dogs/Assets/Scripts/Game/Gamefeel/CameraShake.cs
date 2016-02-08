using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	private GameObject _mainCamera;

	public float intensity = 0.6f;
	public float shakeTime = 0.0f;

	private float _descreaseFactor = 1.0f;

	private Vector3 _originPositionCamera;

	void Awake()
	{
		_mainCamera = GameObject.Find("Main Camera");
	}

	void OnEnable()
	{
		_originPositionCamera = _mainCamera.transform.localPosition;
	}

	void Update()
	{

	}

	public void Shake()
	{
		if(shakeTime > 0)
		{
			_mainCamera.transform.localPosition = _originPositionCamera + Random.insideUnitSphere * intensity;

			shakeTime -= Time.deltaTime * _descreaseFactor;
		}
		else
		{
			shakeTime = 0f;
			_mainCamera.transform.localPosition = _originPositionCamera;
		}
	}
		
}