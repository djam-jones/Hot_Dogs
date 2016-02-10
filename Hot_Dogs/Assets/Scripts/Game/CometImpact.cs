using UnityEngine;
using System.Collections;

public class CometImpact : MonoBehaviour {

	private float _impactForce = 20f;
	private float _impactScaler = 12f;

	private Vector3 _targetPosition = new Vector3(-5f, -3.75f, 0f);
	public GameObject impact;

	void Awake()
	{
		//idk what to put here.
	}

	void Update()
	{
		MoveDown();
	}

	private void MoveDown()
	{
		float step = _impactForce * Time.deltaTime;
		transform.position = Vector2.MoveTowards(transform.position, _targetPosition, step); 

		if(transform.position == _targetPosition)
		{
			StartCoroutine( LerpScaleAndSetInactive() );
			StartCoroutine( Impact() );
		}
	}

	private IEnumerator LerpScaleAndSetInactive()
	{
		Vector3 scale = transform.localScale;
		Vector3 smallScale = new Vector3(0.1f, 0.1f, 0.1f);
		float step = _impactScaler * Time.deltaTime;

		scale = Vector3.Lerp(scale, smallScale, step);
		transform.localScale = scale;

		yield return new WaitForSeconds(0.25f);
		gameObject.SetActive(false);
		yield break;
	}

	private IEnumerator Impact()
	{
		if(!impact.activeInHierarchy)
			impact.SetActive(true);

		yield return new WaitForSeconds(0.25f);
		impact.SetActive(false);
	}


}