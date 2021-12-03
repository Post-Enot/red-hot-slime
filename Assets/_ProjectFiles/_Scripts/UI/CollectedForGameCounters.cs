using UnityEngine;
using UnityEngine.UI;

public class CollectedForGameCounters : MonoBehaviour
{
	[Space]

	[SerializeField] private PlayerProgress _playerProgress;

	[Space]

	[SerializeField] private Text _gemsTextField;
	[SerializeField] private Text _goldTextField;

	private void OnEnable()
	{
		UpdateCounters();
	}

	public void UpdateCounters()
	{
		//if (PlayerProgress.Instance != null)
		//{
		//	_gemsTextField.text = PlayerProgress.Instance.GemsCollectedForGame.Value.ToString();
		//	_goldTextField.text = PlayerProgress.Instance.GoldCollectedForGame.Value.ToString();
		//}
	}
}
