using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace Assets.Scripts.Settings
{
    public class GraphicSettingsApplyer : MonoBehaviour
    {
        [SerializeField] private PostProcessingSettings settings;

        private void Awake()
        {
            settings.OnSettingsUpdated += SetMobilePostProccesing;

            SetMobilePostProccesing();
        }

        private void UpdateSettings()
        {
            switch(settings.PostEffectType)
            {
                case PostEffectType.Mobile:
                    FindObjectOfType<PostProcessor>(true).enabled = true;
                    foreach (var postEffect in FindObjectsOfType<PostEffectsBase>())
                    {
                        postEffect.enabled = false;
                    }
                    break;
                case PostEffectType.PC:
                    FindObjectOfType<PostProcessor>(true).enabled = false;
                    foreach (var postEffect in FindObjectsOfType<PostEffectsBase>())
                    {
                        postEffect.enabled = true;
                    }
                    break;
            }
        }

        private void SetMobilePostProccesing()
        {
            FindObjectOfType<PostProcessor>(true).enabled = true;
            foreach (var postEffect in FindObjectsOfType<PostEffectsBase>())
            {
                postEffect.enabled = false;
            }
        }
    }
}