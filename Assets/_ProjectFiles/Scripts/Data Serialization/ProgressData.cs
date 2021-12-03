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
			OnValueChanged?.Invoke(value);
		}
	}
	private T _value;

	public ProgressData() { }

	public ProgressData(T value = default)
	{
		_value = value;
	}
}
