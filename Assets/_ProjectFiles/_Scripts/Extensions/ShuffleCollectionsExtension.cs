using System.Collections.Generic;
using UnityEngine;

public static class ShuffleCollectionsExtension
{
	/// <summary>
	/// Sorts the collection using the optimized Fisher–Yates algoritm (algoritm P), O(n);
	/// (Using UnityEngine.Random)
	/// </summary>
	public static void Shuffle<T>(this T[] array)
	{
		for (int i = array.Length - 1; i >= 1; i--)
		{
			int randomIndex = Random.Range(0, i + 1);
			T temp = array[randomIndex];
			array[randomIndex] = array[i];
			array[i] = temp;
		}
	}

	/// <summary>
	/// Sorts the collection using the optimized Fisher–Yates algoritm (algoritm P), O(n);
	/// (Using UnityEngine.Random)
	/// </summary>
	public static void Shuffle<T>(this List<T> list)
	{
		for (int i = list.Count - 1; i >= 1; i--)
		{
			int randomIndex = Random.Range(0, i + 1);
			T temp = list[randomIndex];
			list[randomIndex] = list[i];
			list[i] = temp;
		}
	}
}
