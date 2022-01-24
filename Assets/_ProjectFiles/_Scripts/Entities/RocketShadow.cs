using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RocketShadow : GameEffect
{
	[SerializeField] private ProgressArray<Sprite> _states;

	private SpriteRenderer _spriteRenderer;

	private void Start()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void UpdateState(float progress)
	{
		if (_states.CanGetNextValue(progress))
		{
			_spriteRenderer.sprite = _states.GetNextValue();
		}
	}
}
