using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Data Forms/Game Settings", order = 2)]
public sealed class GameSettings : ScriptableObject
{
	[Space]

	[SerializeField] private BoolPrefsField _isMusicEnabled = new BoolPrefsField("is_music_enabled");
	[SerializeField] private BoolPrefsField _isSoundEnabled = new BoolPrefsField("is_sound_enabled");
	[SerializeField] private BoolPrefsField _isVibrationEnabled = new BoolPrefsField("is_vibration_enabled");
	[SerializeField] private StringPrefsField _localizationID = new StringPrefsField("localization_id");
	[SerializeField] private string _defaultLocalizationID;

	public BoolPrefsField IsMusicEnabled => _isMusicEnabled;
	public BoolPrefsField IsSoundEnabled => _isSoundEnabled;
	public BoolPrefsField IsVibrationEnabled => _isVibrationEnabled;
	public StringPrefsField LocalizationID => _localizationID;

	public string DefaultLocalizationID => _defaultLocalizationID;
}
