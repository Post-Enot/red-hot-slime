using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public sealed class TranslatableLabel : TranslatableElement
{
	[SerializeField] private string _textCode;
	private TextMeshProUGUI _text;

	protected override void UpdateTranslate()
	{
		_text ??= GetComponent<TextMeshProUGUI>();
		string text = TextsAtlas.GetTextByCode(_textCode);
		_text.text = text;
	}
}
