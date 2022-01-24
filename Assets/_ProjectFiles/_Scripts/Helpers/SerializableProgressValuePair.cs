using System;
using UnityEngine;

[Serializable]
public struct SerializableProgressValuePair<T>
{
	[SerializeField] private T _value;
	[SerializeField] [Range(0, 1)] private float _minimalProgress;

	public T Value => _value;
	public float MinimalProgress => _minimalProgress;
}
