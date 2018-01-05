using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsTester : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init(){
		AdManager.get ();
	}

	public void loadBanner(){
		AdManager.get ().loadBanner ();
	}

	public void showInterstitial(){
		AdManager.get ().showInterstitial ();
	}

	public void showVideo(){
		AdManager.get ().showVideo ();
	}
}
