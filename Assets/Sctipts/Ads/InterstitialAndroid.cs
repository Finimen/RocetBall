using Assets.Sctipts.MarketSystem;
using UnityEngine;
using UnityEngine.Advertisements;

public enum ReverdType
{
    Coins = 0,
    Heards = 1,
}

public class InterstitialAndroid : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private string androidId = "Rewarded_Android";

    [Space(25)]
    [SerializeField] private ReverdType reverdType = ReverdType.Coins;

    [SerializeField] private int reverd = 50;
    
    [SerializeField] private bool oneView = true;
    [SerializeField] private bool autoLoad;

    private bool loaded;

    private void Awake()
    {
        LoadAd();
    }

    public void LoadAd()
    {
        Debug.Log($"Loading id: {androidId}");

        Advertisement.Load(androidId, this);

        loaded = true;
    }

    public void ShowAd()
    {
        if (!loaded)
        {
            LoadAd();
        }

        loaded = false;

        reverdType = ReverdType.Coins;

        Debug.Log($"Showing id: {androidId}");

        Advertisement.Show(androidId, this);
    }

    public void ShowAdHeards()
    {
        if (!loaded)
        {
            LoadAd();
        }

        loaded = false;

        reverdType = ReverdType.Heards;

        Debug.Log($"Showing id: {androidId}");

        Advertisement.Show(androidId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {

    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("FailedToLoad");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("ShowFailure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Started");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("ShowClick");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        switch (reverdType)
        {
            case ReverdType.Coins:
                FindObjectOfType<Wallet>().IncreaseCoins(reverd);

                if (oneView)
                {
                    gameObject.SetActive(false);
                }

                if (autoLoad)
                {
                    LoadAd();
                }
                break;

            case ReverdType.Heards:
                FindObjectOfType<Heards>(true).ResetCoins();
                FindObjectOfType<Heards>(true).AdsShowed();
                break;
        }
    }
}