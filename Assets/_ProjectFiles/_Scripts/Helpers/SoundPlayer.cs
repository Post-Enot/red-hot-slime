using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public sealed class SoundPlayer : MonoBehaviour
{
	public AudioSource AudioSource { get; private set; }
	public int AudioPriority { get; private set; }

	private void Awake()
	{
		AudioSource = GetComponent<AudioSource>();
	}

	public void PlaySound(AudioClip audioClip, int priority = 0)
	{
		//if (GameSound.Instance.IsEnable)
		//{
		//	if (AudioSource.isPlaying)
		//	{
		//		if (priority >= AudioPriority)
		//		{
		//			StartSoundPlaying(audioClip, priority);
		//		}
		//	}
		//	else
		//	{
		//		StartSoundPlaying(audioClip, priority);
		//	}
		//}
	}

	private void StartSoundPlaying(AudioClip audioClip, int priority)
	{
		AudioPriority = priority;
		AudioSource.clip = audioClip;
		AudioSource.Play();
	}
}
