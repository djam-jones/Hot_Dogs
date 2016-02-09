using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private MenuAnimations _menuAnimsScript;
	private Animator _menuAnim;
	private Animator _cometDogAnim;
	private Animator _cometDogAnim2;

	void Awake()
	{
		_menuAnimsScript = GameObject.Find("Menu Handler").GetComponent<MenuAnimations>();
		_menuAnim = _menuAnimsScript.GetComponent<Animator>();

		_cometDogAnim = GameObject.Find("Comet Dog").GetComponent<Animator>();
		_cometDogAnim2 = GameObject.Find("Comet Dog (1)").GetComponent<Animator>();
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

		_menuAnimsScript.CometDogAnimation(_cometDogAnim);
		_menuAnimsScript.CometDogAnimation(_cometDogAnim2);
		_menuAnimsScript.IntroAnimation(_menuAnim);

		Invoke("LoadGameScene", 4);
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