using System;

public sealed class ProgressData<T>
{
	public event Action<T> OnValueChanged;

	public T Value
	{
		get => _value;
		set
		{
			_value = value;
			if (_indicatableValue != null)
			{
				_indicatableValue.Value = value;
			}
			OnValueChanged?.Invoke(value);
		}
	}
	private T _value;
	private IndicatableValue _indicatableValue;

	public ProgressData(T value = default, IndicatableValue	indicatableValue = null)
	{
		_indicatableValue = indicatableValue;
		Value = value;
	}
}
