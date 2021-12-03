using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Animator), typeof(AudioSource))]
public sealed class Spikes : CellEntity, IEnemy, IPassable
{
	[SerializeField] private float _defaultLifeDuration = 4f;
	[SerializeField] private string _raisedAnimationTrigger = "raised";
	[SerializeField] private string _descendAnimationTrigger = "descend";
	[SerializeField] private AudioClip _raiseSound;
	[SerializeField] private AudioClip _descendSound;

	private Collider2D _collider;
	private Coroutine _lifeTime;
	private Visualizator _skin;

	public void Init()
	{
		_collider = GetComponent<Collider2D>();
		_skin = GetComponent<Visualizator>();
	}

	public void InitSkin(RuntimeAnimatorController animatorController)
	{
		_skin.SetAnimationController(animatorController);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out MainHero mainHero))
		{
			mainHero.Damage();
			StopAllCoroutines();
			Descend();
		}
	}

	public void Raise()
	{
		_collider.enabled = true;
		//_skin.PlaySound(_raiseSound);
		_skin.Animator.SetTrigger(_raisedAnimationTrigger);
		_lifeTime = StartCoroutine(LifeTime(_defaultLifeDuration));
	}

	public void Destroy()
	{
		Destroy(gameObject);
	}

	private void Descend()
	{
		_collider.enabled = false;
		_skin.Animator.SetTrigger(_descendAnimationTrigger);
		//_skin.PlaySound(_descendSound);
	}

	private IEnumerator LifeTime(float lifeDuration)
	{
		yield return new WaitForSeconds(lifeDuration);
		Descend();
	}

	public void Neutralize()
	{
		if (_lifeTime != null)
		{
			StopCoroutine(_lifeTime);
			Descend();
		}
		else
		{
			Destroy();
		}
	}
}
