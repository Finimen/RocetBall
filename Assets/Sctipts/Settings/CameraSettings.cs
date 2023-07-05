using UnityEngine;

namespace Assets.Sctipts.Settings
{
    [CreateAssetMenu(menuName = "Settings/Camera")]
    internal class CameraSettings : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; } = .75f;
        [field: SerializeField] public Vector3 Offest { get; private set; } = new Vector3 (0, 7.5f, -10);
    }
}