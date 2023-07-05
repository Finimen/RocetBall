using Assets.Sctipts.MarketSystem;
using FinimenSniperC.RollerBall;
using UnityEngine;
using UnityEngine.UI;

public class Heards : MonoBehaviour
{
    [SerializeField] private Image[] images;

    [SerializeField] private Canvas canvas;
    [SerializeField] private Canvas[] others;

    [SerializeField] private Button coins;
    [SerializeField] private Button ads;

    [SerializeField] private int price = 25;

    private Wallet wallet;
    private int count;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Heards"))
        {
            count = PlayerPrefs.GetInt("Heards");
        }
        else
        {
            count = 5;
        }

        wallet = FindObjectOfType<Wallet>();

        UpdateUI();
        InitializeButtons();
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("Heards", count);
    }

    public void IncreaseCount()
    {
        count--;

        UpdateUI();

        if (count <= 0)
        {
            FindObjectOfType<Ball>().GetComponent<Rigidbody>().velocity = Vector3.zero;
            FindObjectOfType<BallUserControl>().enabled = false;

            SetActiveCanvases(true);
        }
    }

    public void ResetCoins()
    {
        count = 5;
    }

    private void InitializeButtons()
    {
        coins.onClick.AddListener(() =>
        {
            if (wallet.Coins >= price)
            {
                count = 5;
                wallet.DecreaseCoins(price);

                AdsShowed();
            }
            else
            {
                SetActiveCanvases(false);
            }
        });
    }

    private void UpdateUI()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].transform.GetChild(0).gameObject.SetActive(i < count);
        }
    }

    private void SetActiveCanvases(bool active)
    {
        canvas.gameObject.SetActive(active);
        gameObject.SetActive(!active);

        foreach (var canvas in others)
        {
            canvas.gameObject.SetActive(!active);
        }

        if (!active)
        {
            FindObjectOfType<BallUserControl>().enabled = true;
        }
    }

    public void AdsShowed()
    {
        SetActiveCanvases(false);
        gameObject.SetActive(false);
    }
}