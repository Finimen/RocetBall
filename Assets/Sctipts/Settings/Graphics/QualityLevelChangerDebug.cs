using UnityEngine;

namespace Assets.Scripts.Settings
{
    public class QualityLevelChangerDebug : MonoBehaviour
    {
        private void OnGUI()
        {
            string[] names = QualitySettings.names;

            GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
            GUILayout.FlexibleSpace();

            GUILayout.BeginVertical(GUILayout.Width(150));

            for (int i = 0; i < names.Length; i++)
            {
                if (GUILayout.Button(names[i]))
                {
                    QualitySettings.SetQualityLevel(i, true);
                }
            }

            GUILayout.EndVertical();

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
    }
}