using UnityEngine;

public sealed class GUI : MonoBehaviour
{
	[SerializeField] private GameObject _shop;
	[SerializeField] private GameObject _mainMenu;
	[SerializeField] private GameObject _HUD;
	[SerializeField] private GameObject _settings;
	[SerializeField] private GameObject _gamePause;
	[SerializeField] private GameObject _gameOver;
	[SerializeField] private OpeningLootChest _openingLootChest;

	public Canvas[] Canvases
	{
		get
		{
			_canvases ??= FindObjectsOfType<Canvas>(includeInactive: true);
			return _canvases;
		}
	}

	private Canvas[] _canvases;

	public void GoToOpeningLootChest(HatSkin hat)
	{
		GoTo(_openingLootChest.gameObject);
		_openingLootChest.Show(hat);
	}

	public void GoToShop()
	{
		GoTo(_shop);
	}

	public void GoToMainMenu()
	{
		GoTo(_mainMenu);
	}

	public void GoToPauseWindow()
	{
		GoTo(_gamePause);
	}

	public void GoToSettings()
	{
		GoTo(_settings);
	}

	public void GoToGameEnd()
	{
		GoTo(_gameOver);
	}

	public void GoToHUD()
	{
		GoTo(_HUD);
	}

	private void GoTo(GameObject menu)
	{
		DisableAll();
		menu.SetActive(true);
	}

	private void DisableAll()
	{
		_shop.SetActive(false);
		_HUD.SetActive(false);
		_mainMenu.SetActive(false);
		_settings.SetActive(false);
		_gameOver.SetActive(false);
		_gamePause.SetActive(false);
		_openingLootChest.gameObject.SetActive(false);
	}
}
