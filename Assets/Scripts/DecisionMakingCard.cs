using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class DecisionMakingCard : MonoBehaviour {

	private BannerView bannerView;

	// Use this for initialization
	void Start () {
		string appId = "ca-app-pub-3940256099942544~3347511713";

		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize(appId);

		string adUnitId = "ca-app-pub-3940256099942544/6300978111";
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
		AdRequest request = new AdRequest.Builder().Build();
		bannerView.LoadAd(request);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
