using System;
using UnityEngine;

public sealed class GameLogic : MonoBehaviour
{
	[SerializeField] private SpriteRenderer _downground;

	[Space]

	[SerializeField] private SessionType _sessionType;

	public event Action OnGameOvered;

	public GameServices GameServices { get; private set; }
	public SessionServicesContainer SessionServices { get; private set; }
	public ScoreCounter ScoreCounter { get; private set; }
	public MainHero MainHero { get; private set; }
	public bool IsInit { get; private set; }

	private int _scoreToNextWave;
	private Coroutine _wave;

	public void Init(GameServices gameServices)
	{
		if (!IsInit)
		{
			GameServices = gameServices;
			ScoreCounter = GetComponent<ScoreCounter>();
			//ScoreCounter.Score.OnValueChanged += UpdateGameLoop;
			var gameField = GetComponent<GameField>();
			var entitiesFactory = GetComponent<EntitiesFactory>();
			var effectsFactory = GetComponent<EffectsFactory>();
			SessionServices = new SessionServicesContainer(gameField, entitiesFactory, effectsFactory);
			entitiesFactory.InjectDependepcies(SessionServices, GameServices);
			effectsFactory.InjectDependepcies(SessionServices, GameServices);
			IsInit = true;
		}
		else
		{ 
			ErrorLog.RepeatedClassInit(gameObject);
		}
	}

	public void StartGameLoop(LocationTheme locationTheme)
	{
		SessionServices.EffectsFactory.LocationTheme = locationTheme;
		SessionServices.EntitiesFactory.LocationTheme = locationTheme;
		_downground.sprite = locationTheme.Downground;
		SessionServices.GameField.Init(locationTheme);
		ScoreCounter.StartCounting(GameServices.PlayerProgress.BestScore.Value);
		PrepareMainHero();
	}

	public void FinishGameLoop()
	{
		SessionServices.GameField.Clear();
		Destroy(MainHero.gameObject);
	}

	private void UpdateGameLoop()
	{
		//if (ScoreCounter.Score.Value >= _scoreToNextWave)
		//{
			if (_wave != null)
			{
				StopCoroutine(_wave);
			}
			SessionServices.EntitiesFactory.NeutralizeEnemies();
			Wave wave = _sessionType.GetNextWave();
			_scoreToNextWave += wave.Init(SessionServices);
			_wave = StartCoroutine(wave.Perform());
		//}
	}

	private void PrepareMainHero()
	{
		MainHero = SessionServices.EntitiesFactory.SpawnMainHero(_sessionType.MainHeroSpawnPosition);
		MainHero.OnDied += () => OnGameOvered?.Invoke();
		MainHero.OnDied += StopScoreCounter;
	}

	private void StopScoreCounter()
	{
		int score = ScoreCounter.StopCounting();
		if (score > GameServices.PlayerProgress.BestScore.Value)
		{
			GameServices.PlayerProgress.SaveNewBestScore(score);
		}
	}
}
