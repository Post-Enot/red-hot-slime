using System;
using UnityEngine;
using GoogleMobileAds.Api;

public sealed class Ads : MonoBehaviour
{
	private const string RewardedAdId = "ca-app-pub-1853988191151255/1689202919";
	private const string RewardedInterstitialAdId = "ca-app-pub-1853988191151255/6033682157";

	public bool IsRevive { get; private set; }

	private RewardedAd _rewardedAd;
	private RewardedInterstitialAd _rewardedInterstitialAd;

	private void Awake()
	{
		MobileAds.Initialize(initStatus => { });
	}

	private void Start()
	{
		LoadRewardedAd(default, default);
		LoadRewardedInterstitialAd(default, default);
	}

	private void LoadRewardedAd(object sender, EventArgs args)
	{
		_rewardedAd = new RewardedAd(RewardedAdId);
		_rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
		_rewardedAd.OnAdClosed += LoadRewardedAd;
		AdRequest adRequest = new AdRequest.Builder().Build();
		_rewardedAd.LoadAd(adRequest);
	}

	private void LoadRewardedInterstitialAd(object sender, EventArgs args)
	{

	}

	private void ShowAd(EventHandler<Reward> reward)
	{
		_rewardedAd.OnUserEarnedReward += reward;
		if (_rewardedAd.IsLoaded())
		{
			_rewardedAd.Show();
		}
		else
		{
			LoadRewardedAd(default, default);
		}
	}

	private void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		Handheld.Vibrate();
	}

	public void ResetFlags()
	{
		IsRevive = false;
	}

	public void ShowDoublCollectedTokensAd()
	{
		ShowAd(DoublCollectedTokens);
	}

	public void ShowReviveAd()
	{
		if (!IsRevive)
		{
			ShowAd(Revive);
		}
	}

	private void DoublCollectedTokens(object sender, Reward reward)
	{
		//PlayerProgress.Instance.DoublCollectedTokens();
		//GameLogic.Instance.FinishGameLoop();
	}

	private void Revive(object sender, Reward reward)
	{
		//GameLogic.Instance.ReviveMainHero();
		IsRevive = true;
	}
}
