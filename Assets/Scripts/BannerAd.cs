using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class BannerAd : MonoBehaviour {

    private float reklamBelirmeAni;
    private bool reklamDurumu = false;
    private BannerView reklamObjesi;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
       
        MobileAds.Initialize("ca-app-pub-3716844524138178~8581465046");

        reklamBelirmeAni = Time.time + 2f;

        reklamObjesi = new BannerView("ca-app-pub-3716844524138178/2016056691", AdSize.SmartBanner, AdPosition.Top);
        AdRequest reklamIstegi = new AdRequest.Builder().Build();

        reklamObjesi.LoadAd(reklamIstegi);
    }

    void Update()
    {
        if (Time.time > reklamBelirmeAni)
        {
            reklamBelirmeAni = Time.time + 2f;
            reklamDurumu = !reklamDurumu;

            if (reklamDurumu) {
                reklamObjesi.Show();
                Debug.Log("Banner gösterdi");
            }

            else
            {
                reklamObjesi.Hide();
                Debug.Log("Banner gizlendi");
            }
        }
    }
}
