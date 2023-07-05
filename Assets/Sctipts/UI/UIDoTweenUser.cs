using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIDoTweenUser : MonoBehaviour
{
    public float startAlpha = 1f;
    public float duration = 1f;

    private Text[] texts;
    private Image[] images;

    private void Awake()
    {
        texts = GetComponentsInChildren<Text>(true);
        images = GetComponentsInChildren<Image>(true);
    }

    private void Start()
    {
        SetAlpha(startAlpha);
    }

    public void SetAlpha(float amount)
    {
        foreach (var text in texts)
        {
            text.DOFade(amount, duration);
        }

        foreach (var image in images)
        {
            image.DOFade(amount, duration);
        }

        if(amount == 0)
        {
            DOTween.Sequence()
                .AppendInterval(duration)
                .AppendCallback(() => GetComponent<Canvas>().enabled = (false));
        }
        else
        {
            GetComponent<Canvas>().enabled = (true);
        }
    }
}