using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public sealed class UISound : MonoBehaviour
{
	[SerializeField] [Range(0, 1)] private float _defaultVolume = 0.7f;

	[Space]

	[SerializeField] private AudioClip _scrollButton;
	[SerializeField] private AudioClip _positiveButton;
	[SerializeField] private AudioClip _negativeButton;
	[SerializeField] private AudioClip _newWave;

	private AudioSource _audioSource;
	private GameSettings _gameSettings;

	public void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_audioSource.volume = _defaultVolume;
	}

	public void PlayScrollButton()
	{
		PlaySound(_scrollButton);
	}

	public void PlayPositiveButton()
	{
		PlaySound(_positiveButton);
	}

	public void PlayNegativeButton()
	{
		PlaySound(_negativeButton);
	}

	public void PlayNewWave()
	{
		PlaySound(_newWave);
	}

	private void PlaySound(AudioClip audioClip)
	{
		if (_gameSettings.IsSoundEnabled)
		{
			_audioSource.clip = audioClip;
		}
	}
}
