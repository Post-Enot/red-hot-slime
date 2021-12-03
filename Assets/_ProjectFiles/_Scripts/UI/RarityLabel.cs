using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public sealed class RarityLabel : MonoBehaviour
{
	[SerializeField] private Rarity _defaultRarity = Rarity.Common;

	[SerializeField] private Sprite _commonSprite;
	[SerializeField] private Sprite _rareSprite;
	[SerializeField] private Sprite _epicSprite;
	[SerializeField] private Sprite _legendarySprite;

	private Image _label;

	private void Start()
	{
		Show(_defaultRarity);
	}

	public void Show(Rarity rarity)
	{
		if (_label is null)
		{
			_label = GetComponent<Image>();
		}
		_label.sprite = rarity switch
		{
			Rarity.Common => _commonSprite,
			Rarity.Rare => _rareSprite,
			Rarity.Epic => _epicSprite,
			Rarity.Legendary => _legendarySprite,
			_ => throw new System.NotImplementedException(),
		};
	}
}
