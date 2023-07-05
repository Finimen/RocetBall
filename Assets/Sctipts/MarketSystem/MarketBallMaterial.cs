using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent (typeof (Button))]
    public class MarketBallMaterial : MonoBehaviour
    {
        [SerializeField] private bool isBought;
        [SerializeField] private int price = 100;
        [SerializeField] private Material material;
        [SerializeField] private Image lockedImgage;

        private Market market;

        private void Awake()
        {
            if (!isBought)
            {
                isBought = SaveSystem.LoadBool(nameof(MarketBallMaterial) + name);
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
                market.CreatePayPanel($"Do you want to buy {gameObject.name} color for {price} coins?", price, EnableMaterial);
            }
            else
            {
                UpdateMaterial();
            }
        }

        private void UpdateMaterial()
        {
            market.SetBallMaterial(material);
        }

        private void EnableMaterial()
        {
            lockedImgage.enabled = false;
            isBought = true;

            SaveSystem.SaveBool(nameof(MarketBallMaterial) + name, isBought);
        }
    }
}