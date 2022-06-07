using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    private void Awake()
    {
        if (Application.isEditor == false)
        {
            Debug.unityLogger.logEnabled = false;
        }
    }

    private InterstitialAd interstitial;
    string adUnitId = "ca-app-pub-3940256099942544/1033173712";
    private void Start()
    {
        MobileAds.Initialize(initstatus => { });
        
    }

    private void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        this.interstitial.Show();
    }

    public void LoadScene(string name)
    {
        RequestInterstitial();
        SceneManager.LoadScene(name);
    }


}
