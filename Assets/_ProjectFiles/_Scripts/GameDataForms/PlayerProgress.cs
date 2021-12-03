using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProgress", menuName = "Data Forms/Player Progress", order = 1)]
public sealed class PlayerProgress : ScriptableObject
{
	public ProgressData<int> Gems { get; private set; }
	public ProgressData<int> Gold { get; private set; }
	// переместить счётчики собранной за игру валюты в другое место
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
		Gems = new ProgressData<int>(dataForm.Gems);
		Gold = new ProgressData<int>(dataForm.Gold);
		EquippedHat = new ProgressData<string>(dataForm.EquippedHat);
		string[] hatIdsArray = dataForm.EquippedHat is null ? new string[0] : dataForm.PurchasedHats;
		PurchasedHats = new UnlockedItemsSet(hatIdsArray);
		BestScore = new ProgressData<int>(dataForm.BestScore);
	}
}
