using UnityEngine.UI;
using UnityEngine;

public class OpeningLootChest : MonoBehaviour
{
	private const string _hatStandIconAnimationState = "strawhat_stand_icon";

	public Animator HatIconAnimator;

	public void Show(HatSkin hatSkin)
	{
		var overrideController = new AnimatorOverrideController(HatIconAnimator.runtimeAnimatorController);
		HatIconAnimator.runtimeAnimatorController = overrideController;
		//overrideController[_hatStandIconAnimationState] = hatSkin.AnimationSet.IconAnimationClip;
	}

	public void GoBack()
	{
		//GUI.Instance.GoToShop();
	}
}
