using DG.Tweening;
using System;
using System.Collections;
using System.Diagnostics.Contracts;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Canvas))]
    public class OptimizedWorldCanvas : MonoBehaviour
    {
        [SerializeField] private AlphaController[] alphaControllers;
        
        [SerializeField] private float duration = 1;
        
        private Canvas canvas;

        public void SetAlpha(float amount)
        {
            foreach(var controller in alphaControllers)
            {
                if (controller.Text)
                {
                    controller.Text.DOFade(amount, duration);

                    if(amount == 0)
                    {
                        StartCoroutine(DistabelCanvas(duration));
                    }
                    else
                    {
                        canvas.enabled = true;
                    }
                }

                if (controller.Image)
                {
                    controller.Image.DOFade(amount, duration);

                    if (amount == 0)
                    {
                        StartCoroutine(DistabelCanvas(duration));
                    }
                    else
                    {
                        canvas.enabled = true;
                    }
                }
            }
        }

        private IEnumerator DistabelCanvas(float delay)
        {
            yield return new WaitForSeconds(delay);

            canvas.enabled = false;
        }

        private void Awake()
        {
            canvas = GetComponent<Canvas>();
        }
    }
}