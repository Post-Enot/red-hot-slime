using System.Collections;
using UnityEngine;

public sealed class ScoreCounter : MonoBehaviour
{
	[SerializeField] private float _secondsInScore = 0.1f;

	//public readonly IndicatableValue<int> Score = new IndicatableValue<int>();
	//public readonly IndicatableValue<int> BestScore = new IndicatableValue<int>();

	private Coroutine _counting;

	public void StartCounting(int currentBestScore)
	{
		_counting = StartCoroutine(Counting());
		//Score.Value = 0;
		//BestScore.Value = currentBestScore;
	}

	public int StopCounting()
	{
		StopCoroutine(_counting);
		//int temp = Score.Value;
		//Score.Value = 0;
		//return temp;
		return 0;
	}

	private IEnumerator Counting()
	{
		while (true)
		{
			yield return new WaitForSeconds(_secondsInScore);
			//Score.Value += 1;
			//if (Score.Value > BestScore.Value)
			//{
			//	BestScore.Value = Score.Value;
			//}
		}
	}
}
