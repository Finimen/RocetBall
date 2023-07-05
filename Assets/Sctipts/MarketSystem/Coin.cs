using Assets.Sctipts.MarketSystem;
using UnityEngine;

namespace Assets.Scripts.MarketSystem
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private GameObject parrent;

        private void Awake()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        public void OnPlayerEnter()
        {
            FindObjectOfType<Wallet>().IncreaseCoins();

            Destroy(parrent);
        }
    }
}