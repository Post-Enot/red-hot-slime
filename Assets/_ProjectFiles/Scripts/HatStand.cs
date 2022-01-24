using UnityEngine;
using UnityEngine.UI;

public class HatStand : MonoBehaviour
{
	private const string _hatStandIconAnimationState = "strawhat_stand_icon";

	public HatIndicator HatIndicator;
	public Animator HatStandAnimator;
	public Image HatStandImage;
	public Image CurrencyIcon;
	public Sprite StandOn;
	public Sprite StandOff;
	public Text CostTextbox;

	[SerializeField] private RarityLabel _rarityLabel;
	[SerializeField] private StoreButton _storeButton;

	private int _hatIndex;

	//private HatSkin HatOnStand => HatStore.Instance.Assortment[_hatIndex];

	private void OnEnable()
	{
		UpdateStand();
	}

	public void MoveLeft()
	{
		//if (--_hatIndex < 0)
		//{
		//	_hatIndex = HatStore.Instance.Assortment.Length - 1;
		//}
		UpdateStand();
	}

	public void MoveRight()
	{
		//if (++_hatIndex >= HatStore.Instance.Assortment.Length)
		//{
		//	_hatIndex = 0;
		//}
		UpdateStand();
	}

	public void DoHatAction()
	{
		//var playerProgress = PlayerProgress.Instance;
		//HatSkin hat = HatOnStand;
		//if (playerProgress.PurchasedHats.Contains(hat.ID))
		//{
		//	GameSound.Instance.PlayPositiveButton();
		//	playerProgress.EquippedHat.Value = playerProgress.EquippedHat.Value == hat ? null : hat;
		//	UpdateStandSprite();
		//}
		//else if (playerProgress.Gems.Value >= hat.Cost)
		//{
		//	playerProgress.Gems.Value -= hat.Cost;
		//	GameSound.Instance.PlayPositiveButton();
		//	playerProgress.PurchasedHats.Add(hat.ID);
		//	UpdateStand();
		//}
		//else
		//{
		//	GameSound.Instance.PlayNegativeButton();
		//}
		UpdateStoreButton();
	}

	private void UpdateStand()
	{
		////HatSkin hat = HatOnStand;
		//_rarityLabel.Show(hat.Rarity);
		//HatIndicator.Init(hat);
		//var overrideController = new AnimatorOverrideController(HatStandAnimator.runtimeAnimatorController);
		////HatStandAnimator.runtimeAnimatorController = overrideController;
		////overrideController[_hatStandIconAnimationState] = hat.AnimationSet.IconAnimationClip;
		////if (PlayerProgress.Instance.PurchasedHats.Contains(hat.Name))
		////{
		////	CostTextbox.gameObject.SetActive(false);
		////	CurrencyIcon.gameObject.SetActive(false);
		////}
		////else
		////{
		////	//CostTextbox.text = hat.Cost.ToString();
		////	CostTextbox.gameObject.SetActive(true);
		////	CurrencyIcon.gameObject.SetActive(true);
		////}
		//UpdateStoreButton();
		//UpdateStandSprite();
	}

	private void UpdateStoreButton()
	{
		//if (PlayerProgress.Instance.PurchasedHats.Contains(HatOnStand.ID))
		//{
		//	if (PlayerProgress.Instance.EquippedHat.CompareWith(HatOnStand))
		//	{
		//		_storeButton.UpdateAction(StoreButton.Actions.Unequip);
		//	}
		//	else
		//	{
		//		_storeButton.UpdateAction(StoreButton.Actions.Equip);
		//	}
		//}
		//else
		//{
		//	_storeButton.UpdateAction(StoreButton.Actions.Buy);
		//}
	}

	private void UpdateStandSprite()
	{
		//HatStandImage.sprite = PlayerProgress.Instance.EquippedHat.Value == HatOnStand ? StandOn : StandOff;
	}
}
