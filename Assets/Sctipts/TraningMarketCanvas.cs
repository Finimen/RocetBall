using UnityEngine;

public class TraningMarketCanvas : MonoBehaviour
{
    [SerializeField] private Canvas market;
    [SerializeField] private Canvas load;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("MarketTraning"))
        {
            gameObject.SetActive(false);
        }
        else
        {
            market.gameObject.SetActive(false);
            load.gameObject.SetActive(false);

            PlayerPrefs.SetInt("MarketTraning", 1);
        }
    }
}