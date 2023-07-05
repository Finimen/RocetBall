using DG.Tweening;
using FinimenSniperC;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class RespawnView : MonoBehaviour
    {
        [SerializeField] private float duration = .5f;
        [SerializeField] private float delay = .25f;
        [SerializeField, Range(0,1)] private float alpha = .5f;

        [SerializeField] private Heards heards;

        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();

            FindObjectOfType<DeadZone>(true).OnPlayerEnter += () =>
            {
                if (FindObjectOfType<WinController>().IsCompleted || heards == null)
                {
                    return;
                }

                heards.IncreaseCount();
                heards.gameObject.SetActive(true);

                DOTween.Sequence()
                .Append(image.DOFade(alpha, duration))
                .AppendInterval(delay)
                .Append(image.DOFade(0, duration))
                .AppendInterval(.25f)
                .AppendCallback(() => heards.gameObject.SetActive(false));
            };
        }
    }
}