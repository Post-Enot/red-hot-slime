using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "ChillWave", menuName = "Scriptable Objects/Chill Wave", order = 5)]
public sealed class ChillWave : Wave
{
	[SerializeField] private UnborderedArray<int> _duration;

	public override int Init(SessionServicesContainer sessionServices)
	{
		IsInit = true;
		return _duration.GetValue(DifficultyLevel);
	}

	public override IEnumerator Perform()
	{
		while (true)
		{
			yield return null;
		}
	}
}
