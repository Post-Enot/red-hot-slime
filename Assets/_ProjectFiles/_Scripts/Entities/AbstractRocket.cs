using System.Collections;
using UnityEngine;

public abstract class AbstractRocket : CellEntity, IEnemy, IPassable
{
	[SerializeField] private string _fallenAnimationTrigger = "fallen";
	[SerializeField] private float _defaultMovingSpeedPerSecond = 5;

	protected Vector3 StartPosition { get; private set; }
	protected Vector3 FinalPosition { get; private set; }
	protected Visualizator Skin { get; set; }

	private float _movingSpeedPerSecond;
	private RocketShadow _shadow;

	public void Init(Vector3 startPosition, Vector3 finalPosition)
	{
		Skin = GetComponent<Visualizator>();
		StartPosition = startPosition;
		FinalPosition = finalPosition;
		_movingSpeedPerSecond = _defaultMovingSpeedPerSecond;
		_shadow = SessionServices.EffectsFactory.SpawnRocketShadow(PositionOnField);
		_ = StartCoroutine(LifeTime());
	}

	public void Neutralize()
	{
		_ = StartCoroutine(Explode());
	}

	protected abstract IEnumerator Explode();

	private IEnumerator LifeTime()
	{
		Skin.Animator.SetTrigger(_fallenAnimationTrigger);
		while (transform.position.y >= FinalPosition.y)
		{
			yield return null;
			Fall();
			_shadow.UpdateState(GetProgress());
		}
		Destroy(_shadow.gameObject);
		_ = StartCoroutine(Explode());
	}

	private void Fall()
	{
		float deltaHeight = _movingSpeedPerSecond * Time.deltaTime;
		var deltaPosition = new Vector3(0, deltaHeight, 0);
		transform.position -= deltaPosition;
	}

	private float GetProgress()
	{
		return (transform.position.y - StartPosition.y) / (FinalPosition.y - StartPosition.y);
	}
}
