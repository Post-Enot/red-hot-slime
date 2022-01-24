using System;

[Serializable]
public sealed class PlayerProgressDataForm
{
	public int Gems;
	public int Gold;
	public int BestScore;
	public string EquippedHat;
	public string[] PurchasedHats;

	public PlayerProgressDataForm() { }

	public PlayerProgressDataForm(PlayerProgress playerProgress)
	{
		Gems = playerProgress.Gems.Value;
		Gold = playerProgress.Gold.Value;
		BestScore = playerProgress.BestScore.Value;
		EquippedHat = playerProgress.EquippedHat.Value;
		PurchasedHats = playerProgress.PurchasedHats.ToArray();
	}
}
