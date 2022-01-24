using UnityEngine;

public sealed class Explosion : GameEntity
{
	private Vector2Int _positionInField;

	public void Init(Vector2Int positionInField)
	{
		_positionInField = positionInField;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out MainHero mainHero))
		{
			mainHero.Damage();
			if (mainHero.PositionOnField == _positionInField)
			{
				mainHero.MoveOnFreeNeighbourCell();
			}
		}
	}

	public void Destroy()
	{
		Destroy(gameObject);
	}
}
