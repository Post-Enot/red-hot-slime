using System.Collections;
using UnityEngine;

public sealed class Rocket : AbstractRocket
{
	[SerializeField] private string _explosionAnimationTrigger = "explosion";
	[SerializeField] private AudioClip _explosionSound;

	public void InitSkin(RuntimeAnimatorController animatorController, AudioClip explosionSound)
	{
		Skin.SetAnimationController(animatorController);
		_explosionSound = explosionSound;
	}

	protected override IEnumerator Explode()
	{
		Skin.Animator.SetTrigger(_explosionAnimationTrigger);
		//Skin.PlaySound(_explosionSound);
		GetComponent<Animator>().enabled = false;
		GetComponent<SpriteRenderer>().enabled = false;
		var fallenSound = GetComponent<AudioSource>();
		//Skin.PlaySound(fallenSound.clip);
		yield return new WaitWhile(() => fallenSound.isPlaying);
		Destroy(gameObject);
	}
}
