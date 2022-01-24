using UnityEngine;

public sealed class ExternalLinks : MonoBehaviour
{
	private const string _officialSiteURL = "https://purple-frog-games.com";
	private const string _privacyPolicy = "https://purple-frog-games.com/privacy_policy.html";

	public static void PutToOfficialSite()
	{
		Application.OpenURL(_officialSiteURL);
	}

	public static void PutToPrivacyPolicy()
	{
		Application.OpenURL(_privacyPolicy);
	}
}
