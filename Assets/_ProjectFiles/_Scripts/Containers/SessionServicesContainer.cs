public sealed class SessionServicesContainer
{
	public readonly GameField GameField;
	public readonly EntitiesFactory EntitiesFactory;
	public readonly EffectsFactory EffectsFactory;

	public SessionServicesContainer(GameField gameField,
								 EntitiesFactory entitiesFactory,
								 EffectsFactory effectsFactory)
	{
		GameField = gameField;
		EntitiesFactory = entitiesFactory;
		EffectsFactory = effectsFactory;
	}
}
