using UnityEngine;

public abstract class UnlockableItemsContainer<T> : MonoBehaviour where T : UnlockableItem
{
	[SerializeField] private T[] _array;

	public T[] Array => _array;

	public T GetByID(string id)
	{
		foreach (T item in _array)
		{
			if (item.ID == id)
			{
				return item;
			}
		}
		return null;
	}
}
