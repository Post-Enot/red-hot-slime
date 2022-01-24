using System;
using UnityEngine;

[Serializable]
public struct UnborderedArray<T>
{
	[SerializeField] private T[] _values;
	[SerializeField] private T _underRangedValue;
	[SerializeField] private T _overRangedValue;

	public T GetValue(int index)
	{
		if (index < 0)
		{
			return _underRangedValue;
		}
		else if (index < _values.Length)
		{
			return _values[index];
		}
		else
		{
			return _overRangedValue;
		}
	}
}
