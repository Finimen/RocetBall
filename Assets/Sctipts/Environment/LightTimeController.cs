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

namespace FinimenSniperC
{
    public enum OnCurveEndMode
    {
        ResetTime = 0,
        DestroyThis = 1,
        Nothing = 2
    }

    public enum LightCurveValueMode
    {
        Set = 0,
        Multilay = 1
    }

    [DisallowMultipleComponent]
    [RequireComponent(typeof(Light))]
    internal class LightTimeController : MonoBehaviour
    {
        [SerializeField] private OnCurveEndMode endMode;

        [SerializeField] private LightCurveValueMode lightCurveValueMode;

        [SerializeField] private LightTimeControllerData controllerData;

        private Light currentLight;

        private Keyframe lastKeyframe;

        private float timeLeft;

        private bool timerStarted;

        private void Awake()
        {
            currentLight = GetComponent<Light>();
        }

        private void Start()
        {
            if(controllerData.LightIntensityCurve.length == 0)
            {
                Destroy(gameObject);

                return;
            }

            lastKeyframe = controllerData.LightIntensityCurve[controllerData.LightIntensityCurve.length - 1];
        }

        private void Update()
        {
            timeLeft += Time.deltaTime;

            switch (lightCurveValueMode)
            {
                case LightCurveValueMode.Set:
                    currentLight.intensity = controllerData.LightIntensityCurve.Evaluate(timeLeft);
                    break;
                case LightCurveValueMode.Multilay:
                    currentLight.intensity *= (float)controllerData.LightIntensityCurve.Evaluate(timeLeft);
                    break;
            }

            currentLight.color = Color.Lerp(currentLight.color, controllerData.LightEndColor, controllerData.TimeColorLerp);

            if (timeLeft > lastKeyframe.time)
            {
                switch (endMode)
                {
                    case OnCurveEndMode.DestroyThis:
                        Destroy(gameObject);
                        break;
                    case OnCurveEndMode.ResetTime:
                        timeLeft = 0;
                        break;
                }
            }
        }
    }
}