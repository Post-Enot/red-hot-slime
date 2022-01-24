using System.IO;
using UnityEngine;

public sealed class GameData : MonoBehaviour
{
	private const string _playerProgressLocalPath = "player_progress";

	public HatsContainer HatsContainer { get; private set; }
	public TextAtlas TextsAtlas { get; private set; }

	public string PlayerProgressPath => CreatePathInGameDirectory(_playerProgressLocalPath);

	public void Init(GameServices gameServices)
	{
		HatsContainer = GetComponentInChildren<HatsContainer>();
		gameServices.PlayerProgress.Upload(PlayerProgressPath);
	}

	public void InitTextsAtlas()
	{
		TextsAtlas = new TextAtlas();
		TextsAtlas.InitTranslateTable("texts_atlas", new CsvFormatter('\n', ';'));
		//TextsAtlas = new TextAtlas(new CsvFormatter('\n', ';'), "ru", "en", "texts_atlas");
	}

	private string CreatePathInGameDirectory(string localPath)
	{
		return Path.Combine(Application.persistentDataPath, localPath);
	}
}
