using UnityEngine;
using System.Collections.Generic;

public sealed class EntitiesFactory : GameEntity
{
	private const int _defaultEnemiesListCapacity = 1_000;

	[SerializeField] private float _rocketLaunchHeight = 10;
	[SerializeField] private float _rocketExplosionHeight = 0.5f;

	[Space]

	[SerializeField] private GameObject _mainHeroPrefab;
	[SerializeField] private GameObject _rocketPrefab;
	[SerializeField] private GameObject _stoneRocketPrefab;
	[SerializeField] private GameObject _fireballPrefab;
	[SerializeField] private GameObject _stonePrefab;
	[SerializeField] private GameObject _spikesPrefab;
	[SerializeField] private GameObject _goldTokenPrefab;
	[SerializeField] private GameObject _gemTokenPrefab;

	private readonly List<GameEntity> _enemies = new List<GameEntity>(_defaultEnemiesListCapacity);

	public LocationTheme LocationTheme { get; set; }

	public void NeutralizeEnemies()
	{
		foreach (GameEntity enemy in _enemies)
		{
			if (enemy != null)
			{
				(enemy as IEnemy).Neutralize();
			}
		}
		_enemies.Clear();
	}

	public MainHero SpawnMainHero(Vector2Int positionOnField)
	{
		var mainHero = SpawnCellEntity<MainHero>(_mainHeroPrefab, positionOnField);
		mainHero.InitSkin(LocationTheme.MainHeroSkin);
		mainHero.Init();
		return mainHero;
	}
	public Rocket SpawnRocket(Vector2Int positionOnField)
	{
		return SpawnAbstractRocket<Rocket>(_rocketPrefab, positionOnField);
	}

	public StoneRocket SpawnStoneRocket(Vector2Int positionOnField)
	{
		return SpawnAbstractRocket<StoneRocket>(_stoneRocketPrefab, positionOnField);
	}

	public Fireball SpawnFireball(Direction movingDirection)
	{
		Vector3 spawnPosition = SessionServices.GameField.GetAttentionMarkPosition(movingDirection);
		var fireball = SpawnGameEntity<Fireball>(_fireballPrefab, spawnPosition, transform);
		fireball.Init(movingDirection);
		return fireball;
	}

	public Stone SpawnStone(Vector2Int positionOnField)
	{
		var stone = SpawnCellEntity<Stone>(_stonePrefab, positionOnField);
		stone.Init();
		return stone;
	}

	public Spikes SpawnSpikes(Vector2Int positionOnField)
	{
		return SpawnCellEntity<Spikes>(_spikesPrefab, positionOnField);
	}

	public Token SpawnGoldToken(Vector2Int positionOnField)
	{
		var goldToken = SpawnCellEntity<Token>(_goldTokenPrefab, positionOnField);
		goldToken.Init(GameServices.PlayerProgress.Gold, GameServices.PlayerProgress.GoldCollectedForGame);
		return goldToken;
	}

	public Token SpawnGemToken(Vector2Int positionOnField)
	{
		var gemToken = SpawnCellEntity<Token>(_gemTokenPrefab, positionOnField);
		gemToken.Init(GameServices.PlayerProgress.Gems, GameServices.PlayerProgress.GemsCollectedForGame);
		return gemToken;
	}

	private T SpawnGameEntity<T>(GameObject entityPrefab, Vector3 position, Transform parent, float rotate = 0) where T : GameEntity
	{
		var rotation = Quaternion.Euler(0, 0, rotate);
		GameObject entityGameObject = Instantiate(entityPrefab, position, rotation, parent);
		var entity = entityGameObject.GetComponent<T>();
		entity.InjectDependepcies(SessionServices, GameServices);
		if (entity is IEnemy)
		{
			_enemies.Add(entity);
		}
		return entity;
	}

	private T SpawnCellEntity<T>(GameObject entityPrefab, Vector2Int positionOnField, Vector3 deltaPosition = default) where T : CellEntity
	{
		FieldCell spawnCell = SessionServices.GameField[positionOnField];
		Vector3 spawnPosition = spawnCell.transform.position + deltaPosition;
		T cellEntity = SpawnGameEntity<T>(entityPrefab, spawnPosition, spawnCell.transform);
		cellEntity.SetFieldCell(positionOnField);
		return cellEntity;
	}

	private T SpawnAbstractRocket<T>(GameObject rocketPrefab, Vector2Int positionOnField) where T : AbstractRocket
	{
		var deltaPosition = new Vector3(0, _rocketLaunchHeight, 0);
		var entity = SpawnCellEntity<T>(rocketPrefab, positionOnField, deltaPosition);
		Vector3 finalPosition = entity.FieldCell.transform.position;
		finalPosition.y += _rocketExplosionHeight;
		entity.Init(entity.transform.position, finalPosition);
		return entity;
	}

	private T SpawnShell<T>(Direction movingDirection) where T : Shell
	{
		return null;
	}
}
