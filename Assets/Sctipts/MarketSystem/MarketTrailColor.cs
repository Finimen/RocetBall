using UnityEngine;
using UnityEngine.UI;

public class MarketTrailColor : MonoBehaviour
{
    [SerializeField] private bool isBought;
    [SerializeField] private int price = 100;
    [SerializeField] private Image lockedImgage;

    private Market market;

    private void Awake()
    {
        if (!isBought)
        {
            isBought = SaveSystem.LoadBool(nameof(MarketTrailColor) + name);
        }

        market = FindObjectOfType<Market>();

        GetComponent<Button>().onClick.AddListener(TryUpdateMaterial);

        if (isBought)
        {
            lockedImgage.enabled = false;
        }
    }

    private void TryUpdateMaterial()
    {
        if (!isBought)
        {
            market.CreatePayPanel($"Do you want to buy {gameObject.name} particles for {price} coins?", price, EnableMaterial);
        }
        else
        {
            UpdateMaterial();
        }
    }

    private void UpdateMaterial()
    {
        market.SetTrail(GetComponent<Image>().color);
    }

    private void EnableMaterial()
    {
        lockedImgage.enabled = false;
        isBought = true;

        SaveSystem.SaveBool(nameof(MarketTrailColor) + name, isBought);
    }
}