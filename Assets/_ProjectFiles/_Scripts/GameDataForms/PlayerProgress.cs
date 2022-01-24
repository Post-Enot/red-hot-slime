using UnityEngine;

[CreateAssetMenu(fileName = "Player Progress", menuName = "Data Containers/Player progress")]
public sealed class PlayerProgress : ScriptableObject
{
	[Header("Indicatable value:")]
	[SerializeField] private IndicatableValue _gemCount;
	[SerializeField] private IndicatableValue _goldCount;
	[SerializeField] private IndicatableValue _bestScore;

	public ProgressData<int> Gems { get; private set; }
	public ProgressData<int> Gold { get; private set; }
	public ProgressData<int> GemsCollectedForGame { get; private set; }
	public ProgressData<int> GoldCollectedForGame { get; private set; }
	public ProgressData<int> BestScore { get; private set; }
	public ProgressData<string> EquippedHat { get; private set; }
	public UnlockedItemsSet PurchasedHats { get; private set; }

	public void Upload(string filePathWithoutExtension)
	{
		var saver = new XmlSaver<PlayerProgressDataForm>();
		var dataForm = saver.Upload(filePathWithoutExtension);
		SynchWithDataForm(dataForm);
	}

	public void Save(string filePathWithoutExtension)
	{
		var dataForm = new PlayerProgressDataForm(this);
		var saver = new XmlSaver<PlayerProgressDataForm>();
		saver.Save(filePathWithoutExtension, dataForm);
	}

	public void SaveNewBestScore(int newBestScore)
	{
		BestScore = new ProgressData<int>(newBestScore);
	}

	public void DoublCollectedTokens()
	{
		Gems.Value += GemsCollectedForGame.Value;
		GemsCollectedForGame.Value *= 2;
		Gold.Value += GoldCollectedForGame.Value;
		GoldCollectedForGame.Value *= 2;
	}

	public void ResetCollectedTokens()
	{
		GemsCollectedForGame = new ProgressData<int>();
		GoldCollectedForGame = new ProgressData<int>();
	}

	private void SynchWithDataForm(PlayerProgressDataForm dataForm)
	{
		Gems = new ProgressData<int>(dataForm.Gems, _gemCount);
		Gold = new ProgressData<int>(dataForm.Gold, _goldCount);
		EquippedHat = new ProgressData<string>(dataForm.EquippedHat);
		string[] hatIdsArray = dataForm.EquippedHat is null ? new string[0] : dataForm.PurchasedHats;
		PurchasedHats = new UnlockedItemsSet(hatIdsArray);
		BestScore = new ProgressData<int>(dataForm.BestScore, _bestScore);
	}
}
