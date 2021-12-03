using System;
using UnityEngine;

[Serializable]
public sealed class BoolPrefsField
{
	[SerializeField] private bool _defaultValue;

	public event Action<bool> OnChanged;

	public bool Value
	{
		get => PlayerPrefs.HasKey(_serializationKey) ? GetPrefs(_serializationKey) : _defaultValue;
		set
		{
			SetPrefs(_serializationKey, value);
			OnChanged?.Invoke(value);
		}
	}

	public static bool operator true(BoolPrefsField boolPrefsField) => boolPrefsField.Value;
	public static bool operator false(BoolPrefsField boolPrefsField) => boolPrefsField.Value;

	private readonly string _serializationKey;

	public BoolPrefsField(string serializationKey)
	{
		_serializationKey = serializationKey;
	}

	public void Switch()
	{
		Value = !Value;
	}

	public static void SetPrefs(string key, bool value)
	{
		int intPreferenceValue = Convert.ToInt32(value);
		PlayerPrefs.SetInt(key, intPreferenceValue);
	}

	public static bool GetPrefs(string key, bool defaultValue = default)
	{
		if (PlayerPrefs.HasKey(key))
		{
			int intPreferenceValue = PlayerPrefs.GetInt(key);
			return Convert.ToBoolean(intPreferenceValue);
		}
		else
		{
			return defaultValue;
		}
	}
}
