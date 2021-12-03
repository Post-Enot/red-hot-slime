using System;
using UnityEngine;

[Serializable]
public sealed class HealthIconSkin : Skin
{
	[Space]

	[SerializeField] private string _emptyIconTriggerName = "empty";
	[SerializeField] private string _resetIconTriggerName = "reset";

	[Space]

	[SerializeField] private GameObject _iconPrefab;

	[Space]

	[SerializeField] private float _distanceBetweenIcons = 0.4f;

	public GameObject IconPrefab => _iconPrefab;
	public string EmptyIconTrggerName => _emptyIconTriggerName;
	public string ResetIconTriggerName => _resetIconTriggerName;
	public float DistanceBetweenIcons => _distanceBetweenIcons;
}
