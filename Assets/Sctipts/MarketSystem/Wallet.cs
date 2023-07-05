using System;
using UnityEngine;

namespace Assets.Sctipts.MarketSystem
{
    internal class Wallet : MonoBehaviour
    {
        [field: SerializeField] public int Coins { get; private set; }

        [SerializeField] private bool infinityCoins;

        public event Action<int> OnCoinsIncreased;

        public void IncreaseCoins(int amount = 1)
        {
            Coins += amount;

            OnCoinsIncreased?.Invoke(Coins);

            PlayerPrefs.SetInt("Coins", Coins);
        }

        public void DecreaseCoins(int amount)
        {
            Coins -= amount;

            OnCoinsIncreased?.Invoke(Coins);

            PlayerPrefs.SetInt("Coins", Coins);
        }

        private void Awake()
        {
            Coins = infinityCoins? int.MaxValue : PlayerPrefs.GetInt("Coins");
        }
    }
}