using UnityEngine;
using TMPro;

public sealed class HUD : MonoBehaviour
{
	[Space]

	[SerializeField] private TextMeshProUGUI _gemsIndicator;
	[SerializeField] private TextMeshProUGUI _goldIndicator;

	[Space]

	[SerializeField] private TextMeshProUGUI _scoreIndicator;
	[SerializeField] private TextMeshProUGUI _bestScoreIndicator;

	public void Init(GameServices gameServices)
	{

	}
}
