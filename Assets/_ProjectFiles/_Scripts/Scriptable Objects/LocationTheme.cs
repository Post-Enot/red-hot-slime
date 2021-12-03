using UnityEngine;

[CreateAssetMenu(fileName = "LocationTheme", menuName = "Scriptable Objects/Location Theme", order = 1)]
public sealed class LocationTheme : ScriptableObject
{
	[SerializeField] private SerializableWeightedList<Sprite> _cellSprites;
	[SerializeField] private SerializableWeightedList<Sprite> _leftGroundSprites;
	[SerializeField] private SerializableWeightedList<Sprite> _middleGroundSprites;
	[SerializeField] private SerializableWeightedList<Sprite> _RightGroundSprites;
	[SerializeField] private Sprite _downground;

	[Space]

	[SerializeField] private MainHeroSkin _mainHeroSkin;
	[SerializeField] private HealthIconSkin _healthIconSkin;

	public SerializableWeightedList<Sprite> CellSprites => _cellSprites;
	public SerializableWeightedList<Sprite> LeftGroundSprites => _leftGroundSprites;
	public SerializableWeightedList<Sprite> MiddleGroundSprites => _middleGroundSprites;
	public SerializableWeightedList<Sprite> RightGroundSprites => _RightGroundSprites;

	public HealthIconSkin HealthIconSkin => _healthIconSkin;
	public MainHeroSkin MainHeroSkin => _mainHeroSkin;

	public Sprite Downground => _downground;
}
