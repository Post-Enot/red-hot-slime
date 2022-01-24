using UnityEngine;

[CreateAssetMenu(fileName = "HatSkin", menuName = "Skins/Hat Skin", order = 0)]
public sealed class HatSkin : UnlockableItem
{
	[Space]

	[SerializeField] private Rarity _rarity;

	[Space]

	[SerializeField] private RuntimeAnimatorController _entityAnimatorController;
	[SerializeField] private RuntimeAnimatorController _uiManikinAnimatorController;
	[SerializeField] private RuntimeAnimatorController _uiIconAnimatorController;

	[Space]

	[SerializeField] private string _jumpTriggerName = "jump";
	[SerializeField] private string _dieTriggerName = "die";
	[SerializeField] private string _reviveTriggerName = "revive";

	public RuntimeAnimatorController EntityAnimatorController => _entityAnimatorController;
	public RuntimeAnimatorController UiManikinAnimatorController => _uiManikinAnimatorController;
	public RuntimeAnimatorController UiIconAnimatorController => _uiIconAnimatorController;

	public string JumpTriggerName => _jumpTriggerName;
	public string DieTriggerName => _dieTriggerName;
	public string ReviveTriggerName => _reviveTriggerName;
	public Rarity Rarity => _rarity;
}
