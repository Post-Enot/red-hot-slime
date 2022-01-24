using System;
using UnityEngine;

[Serializable]
public struct SerializableWeightedValue<T>
{
	public const int MinWeight = 1;
	private const string _weightTooltip = "minimal value is 1. If weight equal 0 or less, value will be ignored.";

	[Tooltip(_weightTooltip)]
	[SerializeField] private int _weight;
	[SerializeField] private T _value;

	public int Weight => _weight;
	public T Value => _value;
}
