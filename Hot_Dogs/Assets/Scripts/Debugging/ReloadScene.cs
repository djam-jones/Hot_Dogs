using UnityEngine;
using System.Collections;

public class ReloadScene : MonoBehaviour {

	private KeyCode _reloadKey = KeyCode.A;

	private void Reload()
	{
		if(Input.GetKeyDown(_reloadKey))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

}