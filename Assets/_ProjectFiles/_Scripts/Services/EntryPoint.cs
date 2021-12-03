using UnityEngine;

public sealed class EntryPoint : MonoBehaviour
{
	[Space]

	[SerializeField] private GameServices _services;
	
	[Space]
	
	[SerializeField] private LocationTheme _locationTheme;

	private void Start()
	{
		_services.Logic.Init(_services);
		_services.Logic.OnGameOvered += ShowGameEndScreen;
		_services.UI.GoToMainMenu();
	}

	public void StartGameLoop()
	{
		_services.UI.GoToHUD();
		_services.Music.PlayGameTheme();
		_services.Logic.StartGameLoop(_locationTheme);
	}

	public void ReviveMainHero()
	{
		_services.Music.PlayGameTheme();
		_services.UI.GoToHUD();
		_services.Logic.MainHero.Revive();
		ContinueGameLoop();
	}

	public void ShowGameEndScreen()
	{
		PauseGameLoop();
		_services.UI.GoToGameEnd();
	}

	public void PauseGameLoop()
	{
		Time.timeScale = 0;
	}

	public void ContinueGameLoop()
	{
		Time.timeScale = 1;
	}

	public void RestartGameLoop()
	{
		FinishGameLoop();
		StartGameLoop();
	}

	public void FinishGameLoop()
	{
		//GestureDetector.Instance.ClearEvent();
		_services.Logic.FinishGameLoop();
		_services.PlayerProgress.ResetCollectedTokens();
		//Ads.Instance.ResetFlags();
		if (_services.PlayerProgress.Gold.Value >= 100)
		{
			_services.UI.GoToShop();
		}
		else
		{
			_services.UI.GoToMainMenu();
		}
		_services.Music.PlayMenuTheme();
		Time.timeScale = 1;
	}
}
