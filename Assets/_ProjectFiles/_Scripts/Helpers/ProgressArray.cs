using System;
using UnityEngine;

[Serializable]
public struct ProgressArray<T> // нужен метод проверки валидности
{
	[SerializeField] private SerializableProgressValuePair<T>[] _array;
	private int _index;

	public bool CanGetNextValue(float progress)
	{
		return _index < _array.Length && progress >= _array[_index].MinimalProgress;
	}

	public T GetNextValue()
	{
		T value = _array[_index].Value;
		_index += 1;
		return value;
	}
}
