using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sctipts.MarketSystem
{
    [RequireComponent(typeof(Wallet))]
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private Text coinsStaticText;
        [SerializeField] private Text coinsFadeText;
        
        [SerializeField] private float duration;

        private void Awake()
        {
            GetComponent<Wallet>().OnCoinsIncreased += UpdateText;
        }

        private void Start()
        {
            if (coinsStaticText != null)
            {
                coinsStaticText.text = $"Coins: {GetComponent<Wallet>().Coins}";
            }
        }

        private void UpdateText(int coins)
        {
            if (coinsFadeText != null)
            {
                DOTween.Sequence()
                .Append(coinsFadeText.DOFade(1, duration))
                .AppendInterval(.25f)
                .Append(coinsFadeText.DOFade(0, duration));
            
                coinsFadeText.text = $"Coins: {coins}";
            }

            if (coinsStaticText != null)
            {
                coinsStaticText.text = $"Coins: {coins}";
            }
        }
    }
}