using System;
using System.Collections;
using UnityEngine;

public abstract class Wave : ScriptableObject
{
	public bool IsInit { get; protected set; }
	public int DifficultyLevel => _difficultyLevel.Value;

	private int? _difficultyLevel;

	public void InitDifficultyLevel(int difficultyLevel)
	{
		if (_difficultyLevel is null)
		{
			_difficultyLevel = difficultyLevel;
		}
		else
		{
			throw new ArgumentException();
		}
	}

	public abstract int Init(SessionServicesContainer sessionServices);
	public abstract IEnumerator Perform();
}
