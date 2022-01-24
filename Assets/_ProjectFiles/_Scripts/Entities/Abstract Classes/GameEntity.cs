using UnityEngine;

public abstract class GameEntity : MonoBehaviour
{
	public SessionServicesContainer SessionServices { get; private set; }
	public GameServices GameServices { get; private set; }

	public void InjectDependepcies(
		SessionServicesContainer sessionServices,
		GameServices gameServices)
	{
		SessionServices = sessionServices;
		GameServices = gameServices;
	}
}
