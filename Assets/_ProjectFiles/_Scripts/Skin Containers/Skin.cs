using System;
using UnityEngine;

[Serializable]
public abstract class Skin
{
	[SerializeField] private RuntimeAnimatorController _animatorController;

	public RuntimeAnimatorController AnimatorController => _animatorController;
}
