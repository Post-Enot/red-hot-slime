using UnityEngine;
using UnityEngine.UI;

public class HatIndicator : MonoBehaviour
{
	public const string UiIdleAnimationState = "ui_main_hero_idle";

	private void Start()
	{
		//PlayerProgress.Instance.EquippedHat.ValueChanged += Init;
		//Init(PlayerProgress.Instance.EquippedHat.Value);
	}

	public void Init(HatSkin hatSkin)
	{
		var animator = GetComponent<Animator>();
		var image = GetComponent<Image>();
		if (hatSkin != null)
		{
			image.color = new Color(1, 1, 1);
			var overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
			animator.runtimeAnimatorController = overrideController;
		}
		else
		{
			image.color = new Color(1, 1, 1, 0);
		}
	}
}
