using System.IO;
using UnityEngine;

public sealed class GameData : MonoBehaviour
{
	private const string _playerProgressLocalPath = "player_progress";

	public HatsContainer HatsContainer { get; private set; }
	public TextAtlas TextsAtlas { get; private set; }

	public string PlayerProgressPath => CreatePathInGameDirectory(_playerProgressLocalPath);

	private void Awake()
	{
		HatsContainer = GetComponentInChildren<HatsContainer>();
		//PlayerProgress.Upload(PlayerProgressPath);
	}

	public void InitTextsAtlas()
	{
		//TextsAtlas = new TextAtlas(new CsvFormatter('\n', ';'), "ru", "en", "texts_atlas");
	}

	private void OnApplicationQuit()
	{
		//PlayerProgress.Upload(PlayerProgressPath);
	}

	private string CreatePathInGameDirectory(string localPath)
	{
		return Path.Combine(Application.persistentDataPath, localPath);
	}
}
