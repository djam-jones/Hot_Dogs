using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private MenuAnimations _menuAnimsScript;
	private Animator _menuAnim;

	void Awake()
	{
		_menuAnimsScript = GameObject.Find("Menu Handler").GetComponent<MenuAnimations>();
		_menuAnim = _menuAnimsScript.GetComponent<Animator>();
	}

	void OnLevelWasLoaded(int level)
	{
		if(level == 0)
		{
			//Do Menu Animations.
			_menuAnimsScript.SwiffUpAnimation(_menuAnim);
		}
	}

	public void StartGame()
	{
		//Loading Screen.

		Invoke("LoadGameScene", 4);
		_menuAnimsScript.IntroAnimation(_menuAnim);
	}

	private void LoadGameScene()
	{
		SceneManager.LoadScene("Physics_Djamali"); //Load Main Scene.
	}

	public void QuitGame()
	{
		//Save Highscore.

		Application.Quit(); //Quit Application.
	}

}