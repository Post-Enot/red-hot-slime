using UnityEngine;

[System.Serializable]
public struct WeightedObject<T> where T : Object
{
	[SerializeField] private int _weight;
	[SerializeField] private T _object;

	public int Weight => _weight;
	public Object Object => _object;
}
