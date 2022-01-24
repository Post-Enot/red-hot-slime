using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public sealed class Stone : CellEntity, IEnemy
{
	public const float DefaultLifeDuration = 5f;

	private const string _destructionAnimationState = "Base Layer.rock_destruction";

	public void Init()
	{
		_ = StartCoroutine(LifeTime(DefaultLifeDuration));
	}

	public void Destroy()
	{
		Destroy(gameObject);
	}

	public void Neutralize()
	{
		StopAllCoroutines();
		var animator = GetComponent<Animator>();
		animator.Play(_destructionAnimationState);
	}

	private IEnumerator LifeTime(float lifeDuration)
	{
		yield return new WaitForSeconds(lifeDuration);
		var animator = GetComponent<Animator>();
		animator.Play(_destructionAnimationState);
	}
}
