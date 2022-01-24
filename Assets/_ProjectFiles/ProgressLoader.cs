using UnityEngine;

public sealed class ProgressLoader : MonoBehaviour
{
	[SerializeField] private PlayerProgress _playerProgress;

	[Header("File pathes:")]
	[SerializeField] private string _playerProgressLocalPath;
	[SerializeField] private string _settingsLocalPath;

	private void Awake()
	{
		_playerProgress.Upload(_playerProgressLocalPath);
	}
}
