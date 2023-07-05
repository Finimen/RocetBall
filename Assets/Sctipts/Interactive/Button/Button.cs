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
using UnityEngine.Events;

namespace FinimenSniperC.Interactive
{
    public enum InvokeType
    {
        Every = 0,
        OnlyPlayer = 1
    }

    [DisallowMultipleComponent]
    internal class Button : MonoBehaviour
    {
        [SerializeField] private ButtonSettings settings;

        [SerializeField] private MeshRenderer[] wires;

        [Space(25)]
        [SerializeField] private UnityEventBool onPlayerState;

        [SerializeField] private UnityEvent onEnabled;
        [SerializeField] private UnityEvent onDisabled;

        [Space(25)]
        [SerializeField] private bool enabledForClick;

        [SerializeField] private bool pressed;

        private MeshRenderer buttonRenderer;
        private AudioSource buttonAudioSource;

        private bool buttonEnabled;

        public void SetEnableForClick(bool enabled)
        {
            enabledForClick = enabled;

            UpdateMaterial();
        }

        public void UpdateButton(Collider other)
        {
            if (!enabledForClick)
            {
                return;
            }

            if (settings.InvokeType == InvokeType.OnlyPlayer && !other.GetComponent<RollerBall.Ball>())
            {
                return;
            }

            buttonEnabled = !buttonEnabled;

            UpdateEvents();

            UpdateMaterial();

            buttonAudioSource.Play();
        }

        private void UpdateEvents()
        {
            if (buttonEnabled)
            {
                onEnabled?.Invoke();
            }
            else
            {
                onDisabled?.Invoke();
            }

            onPlayerState?.Invoke(buttonEnabled);
        }

        private void UpdateMaterial()
        {
            buttonRenderer.material = buttonEnabled ? settings.Red : enabledForClick? settings.Green : settings.Yellow;

            foreach(var renderer in wires)
            {
                renderer.material = buttonEnabled ? settings.Red : enabledForClick ? settings.Green : settings.Yellow;
            }
        }

        private void Awake()
        {
            buttonRenderer = GetComponent<MeshRenderer>();

            buttonAudioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            UpdateMaterial();
        }
    }

    [System.Serializable] public class UnityEventBool : UnityEvent<bool>
    {

    }
}