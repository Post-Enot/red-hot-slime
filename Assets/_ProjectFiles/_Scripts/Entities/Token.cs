using System.Collections;
using UnityEngine;

public sealed class Token : CellEntity, IPassable
{
	[SerializeField] private AudioClip _pickUpSound;

	public const float DefaultLifeDuration = 5f;
	public const float SpawnHeight = 0.25f;

	private ProgressData<int> _gameCurrency;
	private ProgressData<int> _collectedForGame;

	public void Init(ProgressData<int> gameCurrency, ProgressData<int> collectedForGame)
	{
		transform.position = new Vector3()
		{
			x = transform.position.x,
			y = transform.position.y + SpawnHeight,
			z = transform.position.z
		};
		_gameCurrency = gameCurrency;
		_collectedForGame = collectedForGame;
		_ = StartCoroutine(LifeTime(DefaultLifeDuration));
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out MainHero _))
		{
			_gameCurrency.Value += 1;
			_collectedForGame.Value += 1;
			DissposableAudioSource audioSource = SessionServices.EffectsFactory.SpawnDissposableAudioSource();
			audioSource.Init(_pickUpSound);
			Destroy();
		}
	}

	private IEnumerator LifeTime(float lifeDuration)
	{
		yield return new WaitForSeconds(lifeDuration);
		Destroy();
	}

	private void Destroy()
	{
		Destroy(gameObject);
	}
}
