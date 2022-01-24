using UnityEngine;

public static class RandomCollectionsExtension
{
	/// <summary>
	/// Returns a random element of the collection;
	/// (Using UnityEngine.Random)
	/// </summary>
	public static T GetRandomElement<T>(this T[] array, int lowBound, int upBound)
	{
		int i = Random.Range(lowBound, upBound);
		return array[i];
	}

	/// <summary>
	/// Returns a random element of the collection;
	/// (Using UnityEngine.Random)
	/// </summary>
	public static T GetRandomElement<T>(this T[] array, int upBound)
	{
		int i = Random.Range(0, upBound);
		return array[i];
	}

	/// <summary>
	/// Returns a random element of the collection;
	/// (Using UnityEngine.Random)
	/// </summary>
	public static T GetRandomElement<T>(this T[] array)
	{
		int i = Random.Range(0, array.Length);
		return array[i];
	}
}
