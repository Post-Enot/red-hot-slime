using System.Collections.Generic;

public class PurchasedHats
{
	private const int _defaultCapacity = 10;

	private List<string> _purchasedHats;

	public PurchasedHats(string[] purchasedHats, int capacity = _defaultCapacity)
	{
		_purchasedHats = purchasedHats is null
			? new List<string>(capacity)
			: new List<string>(purchasedHats)
			{
				Capacity = capacity
			};
	}

	public bool IsInStock(string hatName)
	{
		return _purchasedHats.Contains(hatName);
	}

	public void Add(string hatName)
	{
		_purchasedHats.Add(hatName);
		//PlayerProgress.Instance.Save();
	}

	public string[] Get()
	{
		return _purchasedHats.ToArray();
	}
}
