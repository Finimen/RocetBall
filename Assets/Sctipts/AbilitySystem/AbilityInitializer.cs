using DG.Tweening;
using FinimenSniperC.RollerBall;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AbilityInitializer : MonoBehaviour
{
    [SerializeField] private Button abilityButton;

    [SerializeField] private TimeDepend timeDilation;
    [SerializeField] private JumpIncrease jumpIncrease;
    [SerializeField] private SpeedIncrease speedIncrease;

    private void Awake()
    {
        var id = PlayerPrefs.GetInt("AbilityId");
        var ball = FindObjectOfType<Ball>();

        if(id == 1)
        {
            timeDilation.InitializeButton(abilityButton, ball);
        }
        else if(id == 2)
        {
            jumpIncrease.InitializeButton(abilityButton, ball);
        }
        else if(id == 3)
        {
            speedIncrease.InitializeButton(abilityButton, ball);
        }
    }
}

public abstract class Ability
{
    [SerializeField] private Sprite icon;

    public void InitializeButton(Button button, Ball ball)
    {
        button.image.sprite = icon;

        InitializeInternal(button, ball);
    }

    protected abstract void InitializeInternal(Button button, Ball ball);
}

[Serializable]
public class SpeedIncrease : Ability
{
    [SerializeField] private float multiplay = 1.5f;
    [SerializeField] private float time = 10f;
    [SerializeField] private float reloadTime = 10;

    [SerializeField] private Color active;

    private Color normal;
    private bool enabled = true;

    protected override void InitializeInternal(Button button, Ball ball)
    {
        button.gameObject.SetActive(true);
        normal = button.image.color;

        button.onClick.AddListener(() =>
        {
            if(enabled)
            {
                button.image.color = active;
                ball.MultiplySpeed(multiplay);

                enabled = false;

                DOTween.Sequence()
                .AppendInterval(time)
                .AppendCallback(() =>
                {
                    button.image.color = normal;

                    ball.MultiplySpeed(1 / multiplay);

                    ball.StartCoroutine(Reload(button.image));
                });
            }
        });
    }

    private IEnumerator Reload(Image image)
    {
        var timer = 0f;
        while(timer < reloadTime)
        {
            timer += Time.deltaTime;

            image.fillAmount = timer / reloadTime;

            yield return null;
        }

        enabled = true;
    }
}

[Serializable]
public class JumpIncrease : Ability
{
    [SerializeField] private float multiplay = 1.5f;

    protected override void InitializeInternal(Button button, Ball ball)
    {
        ball.MultiplyJump(multiplay);
    }
}

[Serializable]
public class TimeDepend : Ability
{
    [SerializeField] private float multiplay = .05f;
    [SerializeField] private float time = 10f;
    [SerializeField] private float reloadTime = 10;

    [SerializeField] private Color active;

    private Color normal;
    private bool enabled = true;

    protected override void InitializeInternal(Button button, Ball ball)
    {
        button.gameObject.SetActive(true);
        normal = button.image.color;

        button.onClick.AddListener(() =>
        {
            if (enabled)
            {
                button.image.color = active;
                Time.timeScale = multiplay;

                enabled = false;

                DOTween.Sequence()
                .AppendInterval(time)
                .AppendCallback(() =>
                {
                    button.image.color = normal;

                    Time.timeScale = multiplay;

                    ball.StartCoroutine(Reload(button.image));
                });
            }
        });
    }

    private IEnumerator Reload(Image image)
    {
        var timer = 0f;
        while (timer < reloadTime)
        {
            timer += Time.deltaTime;

            image.fillAmount = timer / reloadTime;

            yield return null;
        }

        enabled = true;
    }
}