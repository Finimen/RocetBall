using UnityEngine;
using UnityEngine.Advertisements;

public class SkippedAndroid : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidId = "Interstitial_Android";

    [SerializeField, Range(0, 1)] private float chanse;

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
        if(Random.Range(0f, 1f) > chanse)
        {
            return;
        }

        if (!loaded)
        {
            LoadAd();
        }

        loaded = false;

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
        
    }
}