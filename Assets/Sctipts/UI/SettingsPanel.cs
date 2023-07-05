using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private SettingsWindow buttons;

    [SerializeField] private SettingsWindow graphics;
    [SerializeField] private SettingsWindow audio;
    [SerializeField] private SettingsWindow game;

    [SerializeField] private float duration = 1.0f;

    private void Awake()
    {
        return;

        graphics.Initialize();
        audio.Initialize();
        game.Initialize();
        buttons.Initialize();

        Hide();
    }

    public void SetGraphics()
    {
        GetComponent<Canvas>().enabled = true;

        graphics.SetAplha(1, duration);
        audio.SetAplha(0, duration);
        game.SetAplha(0, duration);
        buttons.SetAplha(1, duration);
    }

    public void SetAudio()
    {
        GetComponent<Canvas>().enabled = true;

        graphics.SetAplha(0, duration);
        audio.SetAplha(1, duration);
        game.SetAplha(0, duration);
        buttons.SetAplha(1, duration);
    }

    public void SetGame()
    {
        GetComponent<Canvas>().enabled = true;

        graphics.SetAplha(0, duration);
        audio.SetAplha(0, duration);
        game.SetAplha(1, duration);
        buttons.SetAplha(1, duration);
    }

    public void Hide()
    {
        DOTween.Sequence()
            .AppendInterval(duration)
            .AppendCallback(() => GetComponent<Canvas>().enabled = false);

        graphics.SetAplha(0, duration);
        audio.SetAplha(0, duration);
        game.SetAplha(0, duration);
        buttons.SetAplha(0, duration);
    }

    [Serializable]
    private class SettingsWindow
    {
        [SerializeField] private Transform parrent;

        private Text[] texts;
        private Image[] images;

        private Dropdown[] dropdowns;
        private Button[] buttons;
        private Toggle[] toggles;

        public void Initialize()
        {
            texts = parrent.GetComponentsInChildren<Text>();
            images = parrent.GetComponentsInChildren<Image>();

            dropdowns = parrent.GetComponentsInChildren<Dropdown>();
            buttons = parrent.GetComponentsInChildren<Button>();
            toggles = parrent.GetComponentsInChildren<Toggle>();
        }

        public void SetAplha(float alpha, float duration)
        {
            parrent.gameObject.SetActive(alpha != 0);
            return;

            foreach (var text in texts)
            {
                text.DOFade(alpha, duration);
            }

            foreach (var image in images)
            {
                image.DOFade(alpha, duration);
            }

            SetEnabelInteractiveElements(alpha != 0);
        }

        private void SetEnabelInteractiveElements(bool enabeled)
        {
            
            foreach (var dropdown in dropdowns)
            {
                dropdown.enabled = enabeled;
            }

            foreach(var button in buttons)
            {
                button.enabled = enabeled;
            }

            foreach(var toggle in toggles)
            {
                toggle.enabled = enabeled;
            }
        }
    }
}
