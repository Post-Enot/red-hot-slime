using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public sealed class Visualizator : MonoBehaviour
{
	public Animator Animator { get; private set; }
	public SpriteRenderer SpriteRenderer { get; private set; }

	private void Awake()
	{
		Animator = GetComponent<Animator>();
		SpriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void SetAnimationController(RuntimeAnimatorController animatorController)
	{
		Animator.runtimeAnimatorController = animatorController;
	}
}
