using System.Collections;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{	
	private int _count;
	private int _maxCount;
	private float _displayHeight;

	private Visualizator[] _icons;
	private HealthIconSkin _skin;
	private Coroutine _display;

	public void Init(int count, float displayHeight)
	{
		_count = count;
		_maxCount = count;
		_displayHeight = displayHeight;
		_icons = new Visualizator[_count];

		var iconPosition = new Vector3(
			x: -(count - 1) * 0.5f * _skin.DistanceBetweenIcons,
			y: _displayHeight,
			z: transform.position.z
		);
		iconPosition = transform.TransformPoint(iconPosition);

		for (int i = 0; i < _count; i++)
		{
			GameObject healthIcon = Instantiate(_skin.IconPrefab, iconPosition, new Quaternion(), transform);
			_icons[i] = healthIcon.GetComponent<Visualizator>();
			iconPosition.x += _skin.DistanceBetweenIcons;
		}
		ChangeVisibility(alpha: 0);
	}

	public void InitSkin(HealthIconSkin skin)
	{
		_skin = skin;
	}

	public void ResetAnimation()
	{
		foreach (Visualizator icon in _icons)
		{
			icon.Animator.SetTrigger(_skin.ResetIconTriggerName);
		}
	}

	public void Display(float displayDuration, int healthPointCount)
	{
		if (healthPointCount < 0)
		{
			healthPointCount = 0;
		}
		EmptiedDeltaHealthPoint(healthPointCount);
		if (_display != null)
		{
			StopCoroutine(_display);
		}
		_display = StartCoroutine(Display(displayDuration));
	}

	private void EmptiedDeltaHealthPoint(int healthPointCount)
	{
		Mathf.Clamp(healthPointCount, 0, _maxCount);
		for (int i = healthPointCount; i < _count; i++)
		{
			_icons[i].Animator.SetTrigger(_skin.EmptyIconTrggerName);
		}
		_count = healthPointCount;
	}

	private void ChangeVisibility(float alpha)
	{
		Color color = _icons[0].SpriteRenderer.color;
		color.a = alpha;
		foreach (Visualizator icon in _icons)
		{
			icon.SpriteRenderer.color = color;
		}
	}

	private IEnumerator Display(float displayDuration)
	{
		ChangeVisibility(alpha: 1);
		yield return new WaitForSeconds(displayDuration);
		ChangeVisibility(alpha: 0);
	}
}
