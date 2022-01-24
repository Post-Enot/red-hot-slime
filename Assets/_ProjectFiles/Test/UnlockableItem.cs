using UnityEngine;

public abstract class UnlockableItem : ScriptableObject
{
	[SerializeField] private string _ID;

	public string ID => _ID;
}
