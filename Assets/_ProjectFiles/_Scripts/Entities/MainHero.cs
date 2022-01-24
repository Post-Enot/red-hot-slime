using System;
using System.Collections;
using UnityEngine;

public sealed class MainHero : CellEntity
{
	[SerializeField] private int _maxHealthPoint = 3;
	[SerializeField] private float _defaultMoveSpeed = 4f;
	[SerializeField] private float _intangibilityDuration = 0f;

	[Space]

	[SerializeField] private float _healthDisplayingDuration = 3f;
	[SerializeField] private float _healthIndicatorDisplayHeight = 0.4f;
	[SerializeField] private GestureDetector _gestureDetector;

	public event Action OnDied;

	private int _healthPoint;
	private float _moveSpeed;
	private bool _canMove = true;
	private bool _isIntangible = true;
	private bool _isMovingDeferred;

	private Coroutine _moving;
	private HealthIndicator _healthIndicator;
	private Visualizator _visualizator;
	private SoundPlayer _soundPlayer;
	private MainHeroSkin _mainHeroSkin;

	private void Awake()
	{
		_visualizator = GetComponentInChildren<Visualizator>();
		_soundPlayer = GetComponentInChildren<SoundPlayer>();
	}

	public void Init()
	{
		_healthPoint = _maxHealthPoint;
		_moveSpeed = _defaultMoveSpeed;

		_healthIndicator = SessionServices.EffectsFactory.SpawnHealthIndicator(transform.position, transform);
		_healthIndicator.Init(_maxHealthPoint, _healthIndicatorDisplayHeight);

		var skin = GetComponent<MainHeroSkin>();
		//skin.InitHat();
		//if (skin.Hat != null)
		//{
		//	Animator hatAnimator = skin.Hat.GetComponent<Animator>();
		//	AnimationUpdated += hatAnimator.Play;
		//}
		//AnimationUpdated += _visualizator.Play;
		_gestureDetector.OnSwipe += TrackInput;
	}

	public void InitSkin(MainHeroSkin skin)
	{
		_mainHeroSkin = skin;
		_visualizator.SetAnimationController(skin.AnimatorController);
	}

	private void TrackInput(Swipe swipe)
	{
		if (_canMove && swipe != Swipe.None)
		{
			var delta = Vector2Int.zero;

			if (swipe is Swipe.Up)
			{
				delta = Vector2Int.down;
			}
			else if (swipe is Swipe.Down)
			{
				delta = Vector2Int.up;
			}
			else if (swipe is Swipe.Right)
			{
				delta = Vector2Int.left;
			}
			else if (swipe is Swipe.Left)
			{
				delta = Vector2Int.right;
			}
			_ = TryMoveOn(PositionOnField + delta);
		}
	}

	public void Revive()
	{
		_healthIndicator.ResetAnimation();
		transform.position = FieldCell.transform.position;
		_canMove = true;
		_healthPoint = _maxHealthPoint;
		_visualizator.Animator.SetTrigger(_mainHeroSkin.ReviveTriggerName);
		_ = StartCoroutine(IntangibilityCooldown(5));
	}

	public void MoveOnFreeNeighbourCell()
	{
		foreach (Vector2Int movingDirection in CellNeighborhood.VonNeumann)
		{
			Vector2Int movingCellPosition = PositionOnField + movingDirection;
			if (TryMoveOn(movingCellPosition))
			{
				_isMovingDeferred = false;
				return;
			}
		}
		_isMovingDeferred = true;
	}

	public void Damage(int damage = 1)
	{
		if (_isIntangible && _healthPoint > 0)
		{
			//Vibration.Instance.Vibrate();
			_healthPoint -= damage;
			_healthIndicator.Display(_healthDisplayingDuration, _healthPoint);
			if (_healthPoint <= 0)
			{
				PrepareToDie();
			}
			else
			{
				DisplayDamage();
			}
		}
	}

	public bool TryMoveOn(Vector2Int movingPosition)
	{
		bool canMoveOn = SessionServices.GameField.IsPointInside(movingPosition)
			&& SessionServices.GameField[movingPosition].IsPassable
			&& _canMove;
		if (canMoveOn)
		{
			_soundPlayer.PlaySound(_mainHeroSkin.MoveSound);
			SetFieldCell(movingPosition);
			_moving = StartCoroutine(MoveOn());
		}
		return canMoveOn;
	}

	public void Die()
	{
		OnDied?.Invoke();
	}

	private void DisplayDamage()
	{
		_soundPlayer.PlaySound(_mainHeroSkin.DamageSound);
		SessionServices.EffectsFactory.SpawnDamageEffect(transform.position, transform);
		_ = StartCoroutine(IntangibilityCooldown(_intangibilityDuration));
	}

	private void PrepareToDie()
	{
		_canMove = false;
		if (_moving != null)
		{
			StopCoroutine(_moving);
		}
		GameServices.Music.Pause();
		_soundPlayer.PlaySound(_mainHeroSkin.DeathSound);
		_visualizator.Animator.SetTrigger(_mainHeroSkin.DieTriggerName);
	}

	private IEnumerator IntangibilityCooldown(float duration)
	{
		_isIntangible = false;
		yield return new WaitForSeconds(duration);
		_isIntangible = true;
	}

	private IEnumerator MoveOn()
	{
		var interpolation = new Interpolation(transform.position, transform.parent.position, isInit: true);
		_canMove = false;
		_visualizator.Animator.SetTrigger(_mainHeroSkin.JumpTriggerName);
		do
		{
			yield return null;
			transform.position = interpolation.CalculateSmoosthStep(_moveSpeed);
		}
		while (interpolation.IsInProgress(transform.position));
		_canMove = true;
		if (_isMovingDeferred)
		{
			MoveOnFreeNeighbourCell();
		}
	}
}
