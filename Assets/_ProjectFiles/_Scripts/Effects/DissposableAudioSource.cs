using System.Collections;
using UnityEngine;

public sealed class DissposableAudioSource : MonoBehaviour
{
	public bool IsInit { get; private set; }

	private AudioSource _audioSource;

	public void Init(AudioClip audioClip)
	{
		if (!IsInit)
		{
			_audioSource = GetComponent<AudioSource>();
			_audioSource.clip = audioClip;
			_audioSource.Play();
			_ = StartCoroutine(LifeTime());
			IsInit = true;
		}
		else
		{
			ErrorLog.RepeatedClassInit(gameObject);
		}
	}

	private IEnumerator LifeTime()
	{
		yield return new WaitWhile(() => _audioSource.isPlaying);
		Destroy(gameObject);
	}
}
