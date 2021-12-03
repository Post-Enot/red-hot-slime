using System.Collections.Generic;

public sealed class UnlockedItemsSet
{
	private readonly HashSet<string> _ids;

	public UnlockedItemsSet(string[] ids)
	{
		_ids = new HashSet<string>(ids);
	}

	public string[] ToArray()
	{
		string[] array = new string[_ids.Count];
		_ids.CopyTo(array);
		return array;
	}

	public bool Add(string objectID)
	{
		return _ids.Add(objectID);
	}

	public bool Contains(string objectID)
	{
		return _ids.Contains(objectID);
	}

	public HashSet<string> ExceptWith(IEnumerable<string> other)
	{
		var idsCopy = new HashSet<string>(_ids);
		idsCopy.ExceptWith(other);
		return idsCopy;
	}
}
