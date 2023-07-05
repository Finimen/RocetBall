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
using System.Collections;

namespace FinimenSniperC
{
    public enum KeyControllMode
    {
        Key = 0,
        KeyDown = 1,
        KeyUp = 2
    }

    internal class InputEventController: MonoBehaviour
    {
        [SerializeField] private UnityEvent OnKeyPresed;

        [SerializeField] private KeyControllMode keyControllMode;

        [SerializeField] private KeyCode[] keyCodes = new KeyCode[]{ KeyCode.Space };

        [SerializeField] private bool inputEnabled;

        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();

            SetInputEnabledFalse();
        }

        private void Update()
        {
            if (!inputEnabled)
            {
                return;
            }

            foreach(KeyCode keyCode in keyCodes)
            {
                switch (keyControllMode)
                {
                    case KeyControllMode.Key:
                        if (Input.GetKey(keyCode))
                        {
                            OnKeyPresed.Invoke();
                        }
                        break;
                    case KeyControllMode.KeyDown:
                        if (Input.GetKeyDown(keyCode))
                        {
                            OnKeyPresed.Invoke();
                        }
                        break;
                    case KeyControllMode.KeyUp:
                        if (Input.GetKeyUp(keyCode))
                        {
                            OnKeyPresed.Invoke();
                        }
                        break;
                }
            }
        }

        public void SetInputEnabledTrue()
        {
            inputEnabled = true;
        }

        public void SetInputEnabledFalse()
        {
            inputEnabled = false;
        }
    }
}