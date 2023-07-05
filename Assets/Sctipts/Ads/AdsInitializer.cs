using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private bool testMode;
    [SerializeField] private bool audiDisable = true;

    private string gameID = "5275034";

    public void OnInitializationComplete()
    {
        Debug.Log("Заебись!");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Не заебись!");
    }

    private void Awake()
    {
        Advertisement.Initialize(gameID, testMode, this);
    }

    private void Start()
    {
        if (audiDisable)
        {
            gameObject.SetActive(false);
        }
    }
}