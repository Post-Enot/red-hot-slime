using System.Collections.Generic;
using UnityEngine;

public static class CellNeighborhood
{
	public static IEnumerable<Vector2Int> VonNeumann
	{
		get
		{
			yield return Vector2Int.up;
			yield return Vector2Int.down;
			yield return Vector2Int.right;
			yield return Vector2Int.left;
		}
	}

	public static IEnumerable<Vector2Int> Moore
	{
		get
		{
			yield return Vector2Int.up;
			yield return new Vector2Int(1, 1);
			yield return Vector2Int.right;
			yield return new Vector2Int(1, -1);
			yield return Vector2Int.down;
			yield return new Vector2Int(-1, -1);
			yield return Vector2Int.left;
			yield return new Vector2Int(-1, 1);
		}
	}
}
