using UnityEngine;
using UnityEngine.UI;

public class MarketAbility : MonoBehaviour
{
    [SerializeField] private bool isBought;
    [SerializeField] private int price = 100;

    [SerializeField] private Image lockedImgage;

    [SerializeField] private int id;

    private Market market;

    private void Awake()
    {
        if (!isBought)
        {
            isBought = SaveSystem.LoadBool(nameof(MarketAbility) + name);
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
            market.CreatePayPanel($"Do you want to buy {gameObject.name} ability for {price} coins?", price, EnableAbility);
        }
        else
        {
            UpdateAbility();
        }
    }

    private void UpdateAbility()
    {
        FindObjectOfType<AbilitySaver>().Save(id);
    }

    private void EnableAbility()
    {
        lockedImgage.enabled = false;
        isBought = true;

        SaveSystem.SaveBool(nameof(MarketAbility) + name, isBought);
    }
}