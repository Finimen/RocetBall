using Assets.Scripts.Settings;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Sctipts.Settings
{
    [RequireComponent(typeof(Dropdown))]
    public class PostProcessingChanger : MonoBehaviour
    {
        [SerializeField] private PostProcessingSettings settings;

        private void Awake()
        {
            var dropdown = GetComponent<Dropdown>();

            dropdown.ClearOptions();

            var types = System.Enum.GetNames(typeof(PostEffectType));
            var typesList = new List<string>();

            foreach (var type in types)
            {
                typesList.Add(type);
            }

            dropdown.AddOptions(typesList);
            dropdown.onValueChanged.AddListener(UpdateType);
            dropdown.value = (int)settings.PostEffectType;
        }

        private void Start()
        {
            UpdateType((int)settings.PostEffectType);
        }

        private void UpdateType(int index)
        {
            settings.SetPostEffect((PostEffectType)index);
        }
    }
}