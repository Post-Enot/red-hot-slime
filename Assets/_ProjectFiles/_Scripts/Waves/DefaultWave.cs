using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultWave", menuName = "Scriptable Objects/Default Wave", order = 4)]
public sealed class DefaultWave : Wave
{
	[SerializeField] private int _duration = 200;
	[SerializeField] private UnborderedArray<float> _pauseBetweenEntitiesSpawn;
	[SerializeField] private SerializableWeightedList<SpawnableEntitiesID> _spawnableEntities;

	private SessionServicesContainer _sessionServices;

	public override int Init(SessionServicesContainer sessionServices)
	{
		_sessionServices = sessionServices;
		IsInit = true;
		return _duration;
	}

	public override IEnumerator Perform()
	{
		float pause = _pauseBetweenEntitiesSpawn.GetValue(DifficultyLevel);
		while (true)
		{
			SpawnableEntitiesID entitiesID = _spawnableEntities.AccidentallyChoose();
 			switch (entitiesID)
			{
				case SpawnableEntitiesID.Fireball:
					SpawnEntityWithRandomDirection(_sessionServices.EntitiesFactory.SpawnFireball);
					break;

				case SpawnableEntitiesID.Rocket:
					SpawnEntityOnPassableCell(_sessionServices.EntitiesFactory.SpawnRocket);
					break;

				case SpawnableEntitiesID.StoneRocket:
					SpawnEntityOnPassableCell(_sessionServices.EntitiesFactory.SpawnStoneRocket);
					break;

				case SpawnableEntitiesID.Spikes:
					SpawnEntityOnFreeCell(_sessionServices.EntitiesFactory.SpawnSpikes);
					break;

				case SpawnableEntitiesID.GoldToken:
					SpawnEntityOnFreeCell(_sessionServices.EntitiesFactory.SpawnGoldToken);
					break;

				case SpawnableEntitiesID.GemToken:
					SpawnEntityOnFreeCell(_sessionServices.EntitiesFactory.SpawnGemToken);
					break;
			}
			yield return new WaitForSeconds(pause);
		}
	}

	private void SpawnEntityWithRandomDirection(System.Func<Direction, GameEntity> spawnMethod)
	{
		Direction direction = _sessionServices.GameField.GetRandomDirection();
		_ = spawnMethod(direction);
	}

	private void SpawnEntityOnFreeCell(System.Func<Vector2Int, GameEntity> spawnMethod)
	{
		Vector2Int? spawnPosition = _sessionServices.GameField.GetFreeCellPosition();
		if (spawnPosition != null)
		{
			_ = spawnMethod(spawnPosition.Value);
		}
	}

	private void SpawnEntityOnPassableCell(System.Func<Vector2Int, GameEntity> spawnMethod)
	{
		Vector2Int? spawnPosition = _sessionServices.GameField.GetPassableCellPosition();
		if (spawnPosition != null)
		{
			_ = spawnMethod(spawnPosition.Value);
		}
	}
}
 