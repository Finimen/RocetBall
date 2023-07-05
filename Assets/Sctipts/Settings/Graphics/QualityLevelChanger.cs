using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Settings
{
    [RequireComponent(typeof(Dropdown))]
    public class QualityLevelChanger : MonoBehaviour
    {
        private void Awake()
        {
            var dropdown = GetComponent<Dropdown>();
            dropdown.ClearOptions();

            string[] names = QualitySettings.names;

            dropdown.AddOptions(names.ToList());

            dropdown.onValueChanged.AddListener(UpdateQualityLevel);
            dropdown.value = (int)QualitySettings.currentLevel;
        }

        private void UpdateQualityLevel(int level)
        {
            QualitySettings.SetQualityLevel(level, true);
        }
    }
}