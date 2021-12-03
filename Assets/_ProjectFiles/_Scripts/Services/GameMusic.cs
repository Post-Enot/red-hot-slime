using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public sealed class GameMusic : MonoBehaviour
{
	[SerializeField] [Range(0, 1)] private float _defaultVolume = 0.7f;

	[Space]

	[SerializeField] private AudioClip _menuTheme;
	[SerializeField] private AudioClip _gameTheme;

	private AudioSource _audioSource;
	private GameSettings _gameSettings;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
		_audioSource.volume = _defaultVolume;
	}

	public void PlayMenuTheme()
	{
		PlayAudioClip(_menuTheme);
	}

	public void PlayGameTheme()
	{
		PlayAudioClip(_gameTheme);
	}

	public void Pause()
	{
		_audioSource.Pause();
	}

	public void Play()
	{
		if (_gameSettings.IsMusicEnabled)
		{
			_audioSource.Play();
		}
	}

	private void PlayAudioClip(AudioClip audioClip)
	{
		_audioSource.clip = audioClip;
		Play();
	}
}
