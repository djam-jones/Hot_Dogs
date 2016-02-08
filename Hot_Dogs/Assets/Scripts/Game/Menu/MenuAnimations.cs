using UnityEngine;
using System.Collections;

public class MenuAnimations : MonoBehaviour {

	public void IntroAnimation(Animator anim)
	{
		anim.SetTrigger("Intro");
	}

	public void SwiffUpAnimation(Animator anim)
	{
		anim.SetTrigger("Swiff");
	}
}