using System.Collections;
using System;
using UnityEngine;
using GoogleMobileAds.Api;
public class InsterstitialAd : MonoBehaviour {
    public static InsterstitialAd instance;
    [HideInInspector]
    public int no;
    private InterstitialAd reklamObjesi;
    public string Interstital_ID = "ca-app-pub-3716844524138178~8581465046";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
        MobileAds.Initialize("ca-app-pub-3716844524138178/9511403333");
        YeniReklamAl(null, null);
        
    }

    private void Update()
    {
        if (no >= 4)
        {
            StartCoroutine(ReklamiGoster());
            no = 0;
        }
    }

    IEnumerator ReklamiGoster()
    {
        while (!reklamObjesi.IsLoaded())
            yield return null;

        reklamObjesi.Show();
        Debug.Log("Interstitial gösterdi;");
    }

    public void YeniReklamAl(object sender, EventArgs args)
    {
        if (reklamObjesi != null)
            reklamObjesi.Destroy();

        reklamObjesi = new InterstitialAd(Interstital_ID);
        reklamObjesi.OnAdClosed += YeniReklamAl; // Kullanıcı reklamı kapattıktan sonra çağrılır

        AdRequest reklamIstegi = new AdRequest.Builder().Build();
        reklamObjesi.LoadAd(reklamIstegi);
    }
}
