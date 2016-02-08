using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void OnLevelWasLoaded()
	{
		//Do Menu Animations.
	}

	public void StartGame()
	{
		//Loading Screen.

		SceneManager.LoadScene("Physics_Djamali"); //Load Main Scene.
	}

	public void QuitGame()
	{
		//Save Highscore.

		Application.Quit(); //Quit Application.
	}

}