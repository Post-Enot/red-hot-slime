using UnityEngine;
using System;

[Serializable]
public sealed class GameServices
{
	[SerializeField] private GameLogic _gameLogic;

	[Space]

	[SerializeField] private GameSettings _gameSettings;
	[SerializeField] private PlayerProgress _playerProgress;
	[SerializeField] private GameData _gameData;

	[Space]

	[SerializeField] private GUI _GUI;
	[SerializeField] private UISound _UISound;
	[SerializeField] private GameMusic _gameMusic;

	[Space]

	[SerializeField] private GestureDetector _gestureDetector;

	public GameLogic Logic => _gameLogic;
	public GameSettings Settings => _gameSettings;
	public PlayerProgress PlayerProgress => _playerProgress;
	public GameData Data => _gameData;
	public GUI UI => _GUI;
	public UISound UISound => _UISound;
	public GameMusic Music => _gameMusic;
	public GestureDetector GestureDetector => _gestureDetector;
}
