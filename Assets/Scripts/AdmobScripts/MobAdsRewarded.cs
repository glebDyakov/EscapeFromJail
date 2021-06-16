using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class MobAdsRewarded : MonoBehaviour {

    public Text cointCount;
    private RewardedAd rewardedAd;

    #if UNITY_ANDROID
        private const string rewardedUnitId = "ca-app-pub-3940256099942544/5224354917"; //тестовый айди
    #elif UNITY_IPHONE
        private const string rewardedUnitId = "";
    #else
        private const string rewardedUnitId = "unexpected_platform";
    #endif

	void OnEnable() {
        rewardedAd = new RewardedAd(rewardedUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(adRequest);
	    print("добавляем время");
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
	    ShowRewardedAd();  
    }

    void OnDisable() {
	    print("получаем награду");
        rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
    }

    public void ShowRewardedAd() {
        if (rewardedAd.IsLoaded()) {
            rewardedAd.Show(); 
        }
    }

    public void HandleUserEarnedReward(object sender, Reward args) {
	    cointCount.text = (int.Parse(cointCount.text) * 2).ToString();
        PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") + PlayerPrefs.GetInt ("TextCoinsInLevel"));
        print("смотрим рекламу");
    }
}