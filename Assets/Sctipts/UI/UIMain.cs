/*               
            ░███████╗██╗███╗░░██╗██╗██╗░░░░░██╗███████╗███╗░░██╗   ░██████╗███╗░░██╗██╗██████╗░███████╗██████╗░░
			░██╔════╝██║████╗░██║██║████░░████║██╔════╝████╗░██║   ██╔════╝████╗░██║██║██╔══██╗██╔════╝██╔══██╗░
			░███████╗██║██╔██╗██║██║██║░██░░██║█████╗░░██╔██╗██║   ╚█████╗░██╔██╗██║██║██████╔╝█████╗░░██████╔╝░
			░██╔════╝██║██║╚████║██║██║░░░░░██║██╔══╝░░██║╚████║   ░╚═══██╗██║╚████║██║██╔═══╝░██╔══╝░░██╔══██╗░
			░██║░░░░░██║██║░╚███║██║██║░░░░░██║███████╗██║░╚███║   ██████╔╝██║░╚███║██║██║░░░░░███████╗██║░░██║░
			░╚═╝░░░░░╚═╝╚═╝░░╚══╝╚═╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝   ╚═════╝░╚═╝░░╚══╝╚═╝╚═╝░░░░░╚══════╝╚═╝░░╚═╝░
____________________________________________________________________________________________________________________________________________
                █▀▀▄ █──█ 　 ▀▀█▀▀ █──█ █▀▀ 　 ░█▀▀▄ █▀▀ ▀█─█▀ █▀▀ █── █▀▀█ █▀▀█ █▀▀ █▀▀█ 
                █▀▀▄ █▄▄█ 　 ─░█── █▀▀█ █▀▀ 　 ░█─░█ █▀▀ ─█▄█─ █▀▀ █── █──█ █──█ █▀▀ █▄▄▀ 
                ▀▀▀─ ▄▄▄█ 　 ─░█── ▀──▀ ▀▀▀ 　 ░█▄▄▀ ▀▀▀ ──▀── ▀▀▀ ▀▀▀ ▀▀▀▀ █▀▀▀ ▀▀▀ ▀─▀▀
____________________________________________________________________________________________________________________________________________
*/
using UnityEngine;

namespace FinimenSniperC.UI
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    internal class UIMain : MonoBehaviour
    {
        [SerializeField] private UIColorController[] colorControllers;

        [SerializeField] private GameObject[] uiToActive;

        [SerializeField] private Transform moveToTransform;

        [SerializeField] private float yPosition;

        [SerializeField] private float timeScale = .5f;

        [SerializeField] private bool hideLast = true;

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayClip(AudioClip audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }

        public void Instansate(GameObject gameObjectPrefab)
        {
            Instantiate(gameObjectPrefab);
        }

        public void SetAlphaUIColorControllers(float alpha)
        {
            foreach(UIColorController colorController in colorControllers)
            {
                colorController.SetColorAlpha(alpha);
            }
        }

        public void UIArrayToActive(bool activeState)
        {
            foreach(GameObject ui in uiToActive)
            {
                ui.SetActive(activeState);
            }
        }

        public void HideGameObject(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        public void ShowCursor(bool locked)
        {
            Cursor.visible = true;

            SetCursorLockMode(locked);
        }

        public void HideCursor(bool locked)
        {
            Cursor.visible = false;

            SetCursorLockMode(locked);
        }

        private void SetCursorLockMode(bool locked)
        {
            if (locked)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;
        }

        public void ShowGameObject(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public void DisableMonoBehaviour(MonoBehaviour monoBehaviour)
        {
            monoBehaviour.enabled = false;
        }

        public void EnableMonoBehaviour(MonoBehaviour monoBehaviour)
        {
            monoBehaviour.enabled = true;
        }
    }
}