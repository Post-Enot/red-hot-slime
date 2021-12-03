using UnityEngine;

public sealed class GameField : MonoBehaviour
{
	private const string _fieldObjectName = "Game Field";

	[SerializeField] private int _cellSize = 1;

	[SerializeField] private GameObject _cellPrefab;
	[SerializeField] private GameObject _groundPrefab;

	public FieldCell this[Vector2Int point] => _field[point.y, point.x];

	public int Height => 4;
	public int Width => 4;

	private FieldCell[,] _field;
	private Vector2Int[] _fieldPoints;
	private GameObject _fieldObject;

	public void Init(LocationTheme locationTheme)
	{
		_fieldObject = new GameObject(_fieldObjectName);
		_field = new FieldCell[Height, Width];
		static float CalculateCellPosition(float axisSize, float cellSize)
		{
			float position = -(axisSize * 0.5f);
			return axisSize % 2 == 0 ? position + (cellSize * 0.5f) : position;
		}
		var startPoint = new Vector2()
		{
			x = CalculateCellPosition(Width, _cellSize),
			y = CalculateCellPosition(Height, _cellSize)
		};
		PlaceCells(startPoint, locationTheme);
		startPoint.y -= _cellSize;
		PlaceGround(startPoint, locationTheme);
		FillFieldPointsArray();
	}

	public void Clear()
	{
		Destroy(_fieldObject);
	}

	public int? GetRandomRawIndexByDirection(Direction direction)
	{
		return direction switch
		{
			Direction.None => null,
			Direction.Up => Random.Range(0, Width),
			Direction.Down => Random.Range(0, Width),
			Direction.Left => Random.Range(0, Height),
			Direction.Right => Random.Range(0, Height),
			_ => throw new System.ArgumentException()
		};
	}

	public Vector3 GetAttentionMarkPosition(Direction fireballMovingDirection)
	{
		var position = Vector2Int.zero;
		var indent = Vector3.zero;
		float indentSize = (1) * _cellSize;
		switch (fireballMovingDirection)
		{
			case Direction.Up:
				position.x = Random.Range(0, Width);
				indent.y = -indentSize;
				break;

			case Direction.Down:
				position.x = Random.Range(0, Width);
				position.y = Height - 1;
				indent.y = indentSize;
				break;

			case Direction.Left:
				position.y = Random.Range(0, Height);
				indent.x = -indentSize;
				break;

			case Direction.Right:
				position.x = Width - 1;
				position.y = Random.Range(0, Height);
				indent.x = indentSize;
				break;
		}
		return this[position].transform.position + indent;
	}

	public bool IsPointInside(Vector2Int point)
	{
		return point.x >= 0 && point.x < Width && point.y >= 0 && point.y < Height;
	}

	public Direction GetRandomDirection()
	{
		int value = Random.Range(0, 4);
		return value switch
		{
			0 => Direction.Down,
			1 => Direction.Up,
			2 => Direction.Left,
			3 => Direction.Right,
			_ => throw new System.NotImplementedException()
		};
	}

	public Vector2Int? GetPassableCellPosition()
	{
		_fieldPoints.Shuffle();
		foreach (Vector2Int fieldPoint in _fieldPoints)
		{
			if (this[fieldPoint].isFreeOrWithMainHero)
			{
				return fieldPoint;
			}
		}
		return null;
	}

	public Vector2Int? GetFreeCellPosition()
	{
		_fieldPoints.Shuffle();
		foreach (Vector2Int fieldPoint in _fieldPoints)
		{
			if (this[fieldPoint].IsFree)
			{
				return fieldPoint;
			}
		}
		return null;
	}

	private void FillFieldPointsArray()
	{
		_fieldPoints = new Vector2Int[Height * Width];
		int i = 0;
		for (int y = 0; y < Height; y++)
		{
			for (int x = 0; x < Width; x++)
			{
				_fieldPoints[i++] = new Vector2Int(x, y);
			}
		}
	}

	private GameObject PlaceTile(GameObject prefab, Vector2 position, Sprite sprite)
	{
		GameObject tile = Instantiate(prefab, position, new Quaternion(), _fieldObject.transform);
		SpriteRenderer cellSpriteRenderer = tile.GetComponent<SpriteRenderer>();
		cellSpriteRenderer.sprite = sprite;
		return tile;
	}

	private void PlaceCells(Vector2 position, LocationTheme LocationTheme)
	{
		for (int y = 0; y < Height; y++)
		{
			for (int x = 0; x < Width; x++)
			{
				Sprite cellSprite = LocationTheme.CellSprites.AccidentallyChoose();
				GameObject cell = PlaceTile(_cellPrefab, position, cellSprite);
				_field[y, x] = cell.GetComponent<FieldCell>();
				position.x += _cellSize;
			}
			position.y += _cellSize;
			position.x -= Width;
		}
	}

	private void PlaceGround(Vector2 position, LocationTheme LocationTheme)
	{
		Sprite groundSprite = LocationTheme.LeftGroundSprites.AccidentallyChoose();
		_ = PlaceTile(_groundPrefab, position, groundSprite);
		position.x += _cellSize;
		for (int x = 0; x < Height - 2; x++)
		{
			groundSprite = LocationTheme.MiddleGroundSprites.AccidentallyChoose();
			_ = PlaceTile(_groundPrefab, position, groundSprite);
			position.x += _cellSize;
		}
		groundSprite = LocationTheme.RightGroundSprites.AccidentallyChoose();
		_ = PlaceTile(_groundPrefab, position, groundSprite);
		position.x -= Width - 1;
		position.y += _cellSize;
	}
}
