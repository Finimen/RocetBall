using Assets.Scripts;
using Assets.Sctipts.MarketSystem;
using DG.Tweening;
using System;
using UnityEngine;

public class Market : MonoBehaviour
{
    [SerializeField] private BallView ball;

    [SerializeField] private MassagePanel prefab;

    private Wallet wallet;

    private float upForce = 350;

    private bool forceAdded;

    public void SetBallMaterial(Material material)
    {
        ball.SetBallMaterial(material);
    }

    public void SetParticlesColor(Color color)
    {
        TryAddForce();

        ball.SetParticlesColor(color);
    }

    public void SetTrail(Color color)
    {
        TryAddForce();

        ball.SetTrail(color);
    }

    private void TryAddForce()
    {
        if (!forceAdded)
        {
            ball.GetComponent<Rigidbody>().AddForce(Vector3.up * upForce);

            forceAdded = true;

            DOTween.Sequence()
                .AppendInterval(2f)
                .AppendCallback(() => forceAdded = false);
        }
    }

    public void CreatePayPanel(string massage, int price, Action onBought = null)
    {
        var panel = Instantiate(prefab);

        if(price <= wallet.Coins)
        {
            panel.Initialize(massage, () =>
            {
                onBought?.Invoke();
                wallet.DecreaseCoins(price);
                Destroy(panel.gameObject);
                FindObjectOfType<SkippedAndroid>().ShowAd();
            }, 
            () => Destroy(panel.gameObject));
        }
        else
        {
            panel.Initialize(massage, () =>
            {
                InsufficientFunds();
                Destroy(panel.gameObject);
            },
            () => Destroy(panel.gameObject));
        }
    }

    private void InsufficientFunds()
    {
        var panel = Instantiate(prefab);

        panel.Initialize("Insufficient funds",
                () => Destroy(panel.gameObject),
                () => Destroy(panel.gameObject));
        panel.SetButtonNames("Ok", "Ok");
    }

    private void Awake()
    {
        wallet = FindObjectOfType<Wallet>();
    }
}