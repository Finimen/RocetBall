using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UIClickAudio : MonoBehaviour
    {
        [SerializeField] private AudioClip button;
        [SerializeField] private AudioClip dropdown;
        [SerializeField] private AudioClip toggle;

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();

            foreach (var button in FindObjectsOfType<Button>(true))
            {
                button.onClick.AddListener(PlayButton);
            }

            foreach (var button in FindObjectsOfType<Toggle>(true))
            {
                button.onValueChanged.AddListener((value) => PlayButton());
            }

            foreach (var button in FindObjectsOfType<Dropdown>(true))
            {
                button.onValueChanged.AddListener((value) => PlayButton());
            }
        }

        private void PlayButton()
        {
            audioSource.clip = button;
            audioSource.Play();
        }

        private void PlayDropdown()
        {
            audioSource.clip = dropdown;
            audioSource.Play();
        }

        private void PlayToggle()
        {
            audioSource.clip = toggle;
            audioSource.Play();
        }
    }
}