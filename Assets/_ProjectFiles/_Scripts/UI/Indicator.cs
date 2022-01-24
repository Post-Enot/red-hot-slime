using UnityEngine;
using TMPro;

public sealed class Indicator : MonoBehaviour
{
	[Header("References:")]
	[SerializeField] private IndicatableValue _indicatableValue;

	[Header("Style:")]
	[SerializeField] private string _suffix;
	[SerializeField] private string _prefix;

	private TextMeshProUGUI _textField;

	private void Awake()
	{
		_textField = GetComponent<TextMeshProUGUI>();
		_indicatableValue.OnValueChanged += UpdateTextField;
	}

	private void UpdateTextField(object value)
	{
		_textField.text = _suffix + value.ToString() + _prefix;
	}
}
