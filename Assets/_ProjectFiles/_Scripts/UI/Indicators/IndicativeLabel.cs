using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public abstract class IndicativeLabel : MonoBehaviour
{
	[SerializeField] protected PlayerProgress PlayerProgress;

	private TextMeshProUGUI _indicator;

	private void Awake()
	{
		_indicator = GetComponent<TextMeshProUGUI>();
	}

	public void UpdateIndicator(string value)
	{
		_indicator.text = value;
	}
}
