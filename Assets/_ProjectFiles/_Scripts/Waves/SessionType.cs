using UnityEngine;

public abstract class SessionType : ScriptableObject
{
	[SerializeField] private Vector2Int _mainHeroSpawnPosition;

	public int DifficultyLevel { get; protected set; }
	public Vector2Int MainHeroSpawnPosition => _mainHeroSpawnPosition;

	public abstract Wave GetNextWave();
}
