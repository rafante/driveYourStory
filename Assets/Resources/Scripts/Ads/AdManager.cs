using System;
using GoogleMobileAds.Api;

public class AdManager
{
	private static AdManager instance;
	private AdMode mode;

	//test
	private string _appIdTest = "ca-app-pub-3940256099942544~3347511713";
	private string _bannerIdTest = "ca-app-pub-3940256099942544/6300978111";
	private string _interstitialIdTest = "ca-app-pub-3940256099942544/1033173712";
	private string _videoIdTest = "ca-app-pub-3940256099942544/5224354917";

	//production
	private string _appId = "ca-app-pub-1343647000894788~5116009827";
	private string _bannerId = "ca-app-pub-1343647000894788/7372192400";
	private string _interstitialId = "ca-app-pub-1343647000894788/6021897380";
	private string _videoId = "ca-app-pub-1343647000894788/2597968754";

	public BannerView banner;
	public InterstitialAd interstitial;
	public RewardBasedVideoAd video;

	public string appId { get { return mode == AdMode.TEST ? _appIdTest : _appId; } }

	public string bannerId { get { return mode == AdMode.TEST ? _bannerIdTest : _bannerId; } }

	public string interstitialId { get { return mode == AdMode.TEST ? _interstitialIdTest : _interstitialId; } }

	public string videoId { get { return mode == AdMode.TEST ? _videoIdTest : _videoId; } }

	public AdManager ()
	{
		init ();
	}

	public void init ()
	{
		MobileAds.Initialize (appId);
	}

	public static AdManager get (AdMode mode = AdMode.TEST)
	{
		if (instance == null)
			instance = new AdManager ();
		instance.mode = mode;
		return instance;
	}

	public void setAdMode(AdMode mode){
		this.mode = mode;
	}

	public AdMode getMode(){
		return this.mode;
	}

	public void setBannerId(string id){
		_bannerId = id;
	}

	public void setInterstitialId(string id){
		_interstitialId = id;
	}

	public void setVideoId(string id){
		_videoId = id;
	}

	public void moveBannerTo(int x, int y){
		if (banner != null) {
			banner.SetPosition (x, y);
		}
	}

	public void loadBanner(AdPosition position = AdPosition.Bottom, int sizeX = 200, int sizeY = 80){
		AdSize adSize = new AdSize (sizeX, sizeY);
		banner = new BannerView (bannerId, adSize, position);
		AdRequest request = new AdRequest.Builder ().Build ();
		banner.LoadAd (request);
	}

	public void showInterstitial(){
		string adUnitId = interstitialId;
		interstitial = new InterstitialAd (adUnitId);
		interstitial.OnAdLoaded	+= showInterstitial;
		AdRequest request = new AdRequest.Builder ().Build ();
		interstitial.LoadAd (request);
	}

	public void showVideo(){
		video = RewardBasedVideoAd.Instance;
		string adUnitId = videoId;
		AdRequest request = new AdRequest.Builder ().Build ();
		video.OnAdLoaded += showVideo;
		video.LoadAd (request, adUnitId);
	}

	public void showInterstitial(object sender, EventArgs args){
		((InterstitialAd)sender).Show ();
	}

	public void showVideo(object sender, EventArgs args){
		((RewardBasedVideoAd)sender).Show ();
	}
}

public enum AdMode
{
	TEST,
	PRODUCTION
}