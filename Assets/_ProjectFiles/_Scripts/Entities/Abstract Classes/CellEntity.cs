using UnityEngine;

public abstract class CellEntity : GameEntity
{
	public Vector2Int PositionOnField
	{
		get
		{
			if (!_isPositionSet)
			{
				Debug.LogWarning("Cell's entity position on field wasn't init", this);
			}
			return _positionOnField;
		}
		set => _positionOnField = value;
	}
	public FieldCell FieldCell => SessionServices.GameField[PositionOnField];

	private Vector2Int _positionOnField;
	private bool _isPositionSet;

	public void SetFieldCell(Vector2Int positionOnField)
	{
		if (_isPositionSet)
		{
			FieldCell.RemoveEntity(this);
		}
		else
		{
			_isPositionSet = true;
		}
		PositionOnField = positionOnField;
		FieldCell.PlaceEntity(this);
		transform.parent = FieldCell.transform;
	}
}
