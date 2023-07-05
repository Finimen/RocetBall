using UnityEngine;

namespace Assets.Scripts.Settings
{
    [CreateAssetMenu(menuName = "Settings/LevelUI")]
    public class LevelUISettings : ScriptableObject
    {
        [field: Space(15)]
        [field: SerializeField] public Sprite Locked { get;private set; }

        [field: SerializeField] public Sprite Unlocked { get; private set; }

        [field: SerializeField] public Sprite Completed { get; private set; }

        [field: Space(15)]
        [field: SerializeField] public Color ColorCompleted { get; private set; } = Color.white;
    }
}