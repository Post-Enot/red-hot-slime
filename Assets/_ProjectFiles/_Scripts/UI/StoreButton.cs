using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Button))]
public class StoreButton : MonoBehaviour
{
	[SerializeField] private Sprite _buyingSprite;
	[SerializeField] private Sprite _equiptingSprite;
	[SerializeField] private Sprite _unequiptingSprite;

	private Image _image;

	public enum Actions : byte
	{
		Buy = 1,
		Equip = 2,
		Unequip = 3
	}

	public Actions Action { get; private set; } = Actions.Buy;

	public void UpdateAction(Actions action)
	{
		Action = action;
		UpdateActionSprite();
	}

	private void UpdateActionSprite()
	{
		if (_image is null)
		{
			_image = GetComponent<Image>();
		}
		_image.sprite = Action switch
		{
			Actions.Buy => _buyingSprite,
			Actions.Equip => _equiptingSprite,
			Actions.Unequip => _unequiptingSprite,
			_ => throw new System.NotImplementedException(),
		};
	}
}
