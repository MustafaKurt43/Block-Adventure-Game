using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class AdManager : MonoBehaviour
{
    private BannerView bannerad;
    private InterstitialAd interstitial;
    private string Appid = "ca-app-pub-7445424998472406~8867095871";
    public static AdManager Instance;
    private void Awake()
    {
      if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
            return;
        }
    }
    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        this.RequestBanner();
    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-7445424998472406/1894531407";
        this.bannerad = new BannerView(adUnitId, AdSize.SmartBanner,AdPosition.Bottom);
        this.bannerad.LoadAd(this.CreateAdRequest());

    }

   public void RequestInterstitial()
    {
        string adUnýtId = "ca-app-pub-7445424998472406/8329746115";
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }
        this.interstitial = new InterstitialAd(adUnýtId);
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    public void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            Debug.Log("Interstitial Ad is not ready yet");
        }
    }

    void Update()
    {
        
    }
}
