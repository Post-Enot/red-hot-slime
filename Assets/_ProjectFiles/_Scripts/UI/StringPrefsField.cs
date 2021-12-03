using System;
using UnityEngine;

[Serializable]
public sealed class StringPrefsField
{
	[SerializeField] private string _defaultValue;

	public event Action<string> OnChanged;

	public string Value
	{
		get => PlayerPrefs.HasKey(_serializationKey) ? PlayerPrefs.GetString(_serializationKey) : _defaultValue;
		set
		{
			PlayerPrefs.SetString(_serializationKey, value);
			OnChanged?.Invoke(value);
		}
	}

	private readonly string _serializationKey;

	public StringPrefsField(string serializationKey)
	{
		_serializationKey = serializationKey;
	}
}
