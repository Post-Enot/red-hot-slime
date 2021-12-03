using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableWeightedList<T> : IRandomWeightable<T>
{
	private const string _weightedValuesTooltip = "Do not change in play mode";

	[Tooltip(_weightedValuesTooltip)]
	[SerializeField] private SerializableWeightedValue<T>[] _weightedValues;

	private readonly Func<int, int, int> _defaultRandomNumberGenerator = (int minInclusive, int maxInclusive) =>
	{
		return UnityEngine.Random.Range(minInclusive, maxInclusive);
	};
	private int _totalWeight;

	public bool IsValidate { get; private set; }
	public int Count => _weightedValues.Length;

	public void Validate()
	{
		var validableValues = new List<SerializableWeightedValue<T>>(_weightedValues.Length);
		foreach (SerializableWeightedValue<T> weightedValue in _weightedValues)
		{
			if (weightedValue.Weight >= SerializableWeightedValue<T>.MinWeight)
			{
				_totalWeight += weightedValue.Weight;
				validableValues.Add(weightedValue);
			}
		}
		_weightedValues = validableValues.ToArray();
		IsValidate = true;
	}

	public T AccidentallyChoose(Func<int, int, int> randomNumberGenerator = null, T alternativeResult = default)
	{
		randomNumberGenerator ??= _defaultRandomNumberGenerator;
		if (!IsValidate)
		{
			Validate();
		}
		int randomWeight = randomNumberGenerator(SerializableWeightedValue<T>.MinWeight, _totalWeight);
		foreach (SerializableWeightedValue<T> weightedValue in _weightedValues)
		{
			randomWeight -= weightedValue.Weight;
			if (randomWeight <= 0)
			{
				return weightedValue.Value;
			}
		}
		for (int i = 0; i < _weightedValues.Length; i++)
		{
			randomWeight -= _weightedValues[i].Weight;
			if (randomWeight <= 0)
			{
				return _weightedValues[i].Value;
			}
		}
		return alternativeResult;
	}
}
