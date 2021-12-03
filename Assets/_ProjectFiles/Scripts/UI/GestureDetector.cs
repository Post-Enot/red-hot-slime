using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class GestureDetector : MonoBehaviour
{
	[SerializeField] private int _defaultSensitivity = 50;

	public event Action<Swipe> OnSwipe;

	private PlayerInputActions _inputActions;
	private Coroutine _swipeDetection;
	private Vector2 _touchStartPosition;
	private int _sqrSensitivity;

	private void Awake()
	{
		_inputActions = new PlayerInputActions();
	}

	private void Start()
	{
		_sqrSensitivity = _defaultSensitivity * _defaultSensitivity;
		_inputActions.Touch.PrimaryContact.started += context => StartSwipeDetection(context);
		_inputActions.Touch.PrimaryContact.canceled += context => FinalSwipeDetection(context);
	}

	private void OnEnable()
	{
		_inputActions.Enable();
	}

	private void OnDisable()
	{
		_inputActions.Disable();
	}

	private void StartSwipeDetection(InputAction.CallbackContext context)
	{
		_touchStartPosition = _inputActions.Touch.PrimaryPosition.ReadValue<Vector2>();
		_swipeDetection = StartCoroutine(SwipeDetection());
	}

	private void FinalSwipeDetection(InputAction.CallbackContext context)
	{
		if (_swipeDetection != null)
		{
			StopCoroutine(SwipeDetection());
		}
	}

	private IEnumerator SwipeDetection()
	{
		while (true)
		{
			yield return null;
			var position = _inputActions.Touch.PrimaryPosition.ReadValue<Vector2>() - _touchStartPosition;
			if (position.sqrMagnitude >= _sqrSensitivity)
			{
				Swipe swipe = DefineSwipe(position, _defaultSensitivity);
				OnSwipe?.Invoke(swipe);
				yield break;
			}
		}
	}

	public void ClearEvent()
	{
		OnSwipe = null;
	}

	public static Swipe DefineSwipe(Vector2 deltaPosition, int sensitivity)
	{
		// Remember: swipeDirection - inverse of touch moving direction:
		// if ( touchMovingDirection == right ) then
		// swipeDirection = left ; etc.
		Swipe swipe = Swipe.None;
		if (Vector2.Dot(deltaPosition, Vector2.right) > sensitivity)
		{
			swipe |= Swipe.Left;
		}
		else if (Vector2.Dot(deltaPosition, Vector2.left) > sensitivity)
		{
			swipe |= Swipe.Right;
		}
		if (Vector2.Dot(deltaPosition, Vector2.up) > sensitivity)
		{
			return swipe | Swipe.Down;
		}
		else if (Vector2.Dot(deltaPosition, Vector2.down) > sensitivity)
		{
			return swipe | Swipe.Up;
		}
		return swipe;
	}
}