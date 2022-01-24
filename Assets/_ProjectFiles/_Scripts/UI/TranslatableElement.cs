using UnityEngine;

public abstract class TranslatableElement : MonoBehaviour
{
	protected TextAtlas TextsAtlas;

	public void InitTextAtlas(TextAtlas textsAtlas)
	{
		TextsAtlas = textsAtlas;
		TextsAtlas.OnLanguageChanged += UpdateTranslate;
		UpdateTranslate();
	}

	protected abstract void UpdateTranslate();
}
