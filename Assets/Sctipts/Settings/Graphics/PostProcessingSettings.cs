using System;
using UnityEngine;

namespace Assets.Scripts.Settings
{
    [CreateAssetMenu(menuName = "Settings/PostProcessing")]
    public class PostProcessingSettings : ScriptableObject
    {
        [field: SerializeField] public PostEffectType PostEffectType { get; private set; }

        public event Action OnSettingsUpdated;

        public void SetPostEffect(PostEffectType postEffectType)
        {
            PostEffectType = postEffectType;

            OnSettingsUpdated?.Invoke();
        }
    }
}