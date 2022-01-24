using System.Collections.Generic;
using UnityEngine;

public class HatChest : MonoBehaviour
{
	public const int OpeningPrice = 100;

	public void OpenChest()
	{
		//if (PlayerProgress.Instance.Gold.Value >= OpeningPrice)
		//{
		//	//List<HatForm> notReceivedHats = HatStore.Instance.GetNotReceivedHats();
		//	//if (notReceivedHats.Count != 0)
		//	//{
		//	//	PlayerProgress.Instance.Gold.Value -= OpeningPrice;
		//	//	HatForm hat = notReceivedHats.GetRandomElementByWeight();
		//	//	GameSound.Instance.PlayPositiveButton();
		//	//	PlayerProgress.Instance.PurchasedHats.Add(hat.Name);
		//	//	GameUI.Instance.GoToOpeningLootChest(hat);
		//	//}
		//	//else
		//	//{
		//	//	GameSound.Instance.PlayNegativeButton();
		//	//}
		//}
		//else
		//{
		//	GameSound.Instance.PlayNegativeButton();
		//}
	}
}
