using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Indicatable Value", menuName ="UI/Indicatable value")]
public sealed class IndicatableValue : ScriptableObject
{
	public object Value
	{
		get => _value;
		set
		{
			_value = value;
			OnValueChanged?.Invoke(_value);
		}
	}

	public event Action<object> OnValueChanged;

	[NonSerialized] private object _value;
}
