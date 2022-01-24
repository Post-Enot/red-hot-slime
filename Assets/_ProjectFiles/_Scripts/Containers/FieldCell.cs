using UnityEngine;

public class FieldCell : MonoBehaviour
{
	private CellEntity _entity;
	private MainHero _mainHero;

	public bool IsFree => _mainHero == null && _entity == null;
	public bool isFreeOrWithMainHero => _entity == null;
	public bool IsPassable => IsFree || _entity is IPassable;
	public CellEntity Entity => _entity;
	public MainHero MainHero => _mainHero;

	public void PlaceEntity(CellEntity cellEntity)
	{
		if (cellEntity is MainHero)
		{
			_mainHero = cellEntity as MainHero;
		}
		else
		{
			_entity = cellEntity;
		}
	}

	public void RemoveEntity(CellEntity cellEntity)
	{
		if (cellEntity is MainHero)
		{
			_mainHero = null;
		}
		else
		{
			_entity = null;
		}
	}
}
