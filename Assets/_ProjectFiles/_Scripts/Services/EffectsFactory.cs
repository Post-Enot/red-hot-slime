using UnityEngine;

public sealed class EffectsFactory : GameEntity
{
	[SerializeField] private GameObject _dissposableAudioSourcePrefab;
	[SerializeField] private GameObject _rocketShadowPrefab;
	[SerializeField] private GameObject _attentionMarkPrefab;
	[SerializeField] private GameObject _damageEffectPrefab;
	[SerializeField] private GameObject _healthIndicatorPrefab;

	public LocationTheme LocationTheme { get; set; }

	public DissposableAudioSource SpawnDissposableAudioSource()
	{
		return SpawnEffect<DissposableAudioSource>(_dissposableAudioSourcePrefab, Vector3.zero, transform);
	}

	public RocketShadow SpawnRocketShadow(Vector2Int positionOnField)
	{
		FieldCell cell = SessionServices.GameField[positionOnField];
		return SpawnEffect<RocketShadow>(_rocketShadowPrefab, cell.transform.position, cell.transform);
	}

	public HealthIndicator SpawnHealthIndicator(Vector3 position, Transform parent)
	{
		var healthIndicator = SpawnEffect<HealthIndicator>(_healthIndicatorPrefab, position, parent);
		healthIndicator.InitSkin(LocationTheme.HealthIconSkin);
		return healthIndicator;
	}

	public Transform SpawnDamageEffect(Vector3 position, Transform parent)
	{
		return SpawnEffect<Transform>(_damageEffectPrefab, position, parent);
	}

	private T SpawnEffect<T>(GameObject effectPrefab, Vector3 position, Transform parent) where T : Component
	{
		var rotation = new Quaternion();
		GameObject effectObject = Instantiate(effectPrefab, position, rotation, parent);
		return effectObject.GetComponent<T>();
	}
}
