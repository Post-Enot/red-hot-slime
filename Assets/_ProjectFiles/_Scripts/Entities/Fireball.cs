using System.Collections;
using UnityEngine;

public sealed class Fireball : GameEntity, IEnemy
{
	public const float DistanceToScreen = 5.5f;
	public const float DefaultMovingSpeed = 0.25f;

	private readonly float _movingSpeed = DefaultMovingSpeed;

	[SerializeField] private GameObject _attentionMark;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == _attentionMark)
		{
			Destroy(_attentionMark);
		}
		else
		{
			if (collision.gameObject.TryGetComponent(out MainHero mainHero))
			{
				mainHero.Damage();
				Destroy(gameObject);
				Destroy(_attentionMark);
			}
		}
	}

	public void Init(Direction movingDirection)
	{
		_attentionMark.transform.parent = transform.parent;
		Vector3 position = CalculatePosition(movingDirection);
		Quaternion rotation = CalculateRotation(movingDirection);
		transform.SetPositionAndRotation(position, rotation);
		Vector3 finalPosition = CalculateFinalPosition(movingDirection);
		_ = StartCoroutine(Move(finalPosition));
	}

	private Vector3 CalculatePosition(Direction movingDirection)
	{
		var position = _attentionMark.transform.position;
		return movingDirection switch
		{
			Direction.Up => new Vector3(position.x, -DistanceToScreen, position.z),
			Direction.Down => new Vector3(position.x, DistanceToScreen, position.z),
			Direction.Right => new Vector3(DistanceToScreen, position.y, position.z),
			Direction.Left => new Vector3(-DistanceToScreen, position.y, position.z),
			_ => throw new System.NotImplementedException()
		};
	}

	private Quaternion CalculateRotation(Direction movingDirection)
	{
		return movingDirection switch
		{
			Direction.Up => Quaternion.Euler(0, 0, 90),
			Direction.Down => Quaternion.Euler(0, 0, -90),
			Direction.Right => Quaternion.Euler(0, 0, 180),
			Direction.Left => Quaternion.Euler(0, 0, 0),
			_ => throw new System.NotImplementedException()
		};
	}

	private Vector3 CalculateFinalPosition(Direction movingDirection)
	{
		Vector3 position = transform.position;
		return movingDirection switch
		{
			Direction.Up => new Vector3(position.x, DistanceToScreen, position.z),
			Direction.Down => new Vector3(position.x, -DistanceToScreen, position.z),
			Direction.Right => new Vector3(-DistanceToScreen, position.y, position.z),
			Direction.Left => new Vector3(DistanceToScreen, position.y, position.z),
			_ => throw new System.NotImplementedException()
		};
	}

	private IEnumerator Move(Vector3 finalPosition)
	{
		var interpolation = new Interpolation(transform.position, finalPosition, isInit: true);
		do
		{
			yield return null;
			transform.position = interpolation.CalculateLerp(_movingSpeed);
		}
		while (interpolation.IsInProgress(transform.position));
		Destroy(gameObject);
	}

	public void Neutralize()
	{
		Destroy(gameObject);
	}
}
