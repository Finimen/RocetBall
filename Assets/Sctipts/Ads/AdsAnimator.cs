using DG.Tweening;
using UnityEngine;

public class AdsAnimator : MonoBehaviour
{
    private float duration = 1.75f;

    private void Awake()
    {
        transform.rotation = Quaternion.Euler(0, 0, 10);

        DOTween.Sequence()
            .Append(transform.DORotate(new Vector3(0, 0, -10), duration)).SetEase(Ease.InOutQuad)
            .Append(transform.DORotate(new Vector3(0, 0, 10), duration)).SetEase(Ease.InOutQuad)
            .SetLoops(-1);
    }
}