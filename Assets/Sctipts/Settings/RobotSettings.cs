using UnityEngine;

[CreateAssetMenu(menuName = "Settings/RobotSettings")]
public class RobotSettings : ScriptableObject
{
    [field: SerializeField] public Rigidbody Coin { get; private set; }
    [field: SerializeField] public Color DamagedColor { get; private set; } = Color.red;
    [field: SerializeField, Range(0, 1)] public float CoinsDropChanse { get; private set; } = .1f;
    [field: SerializeField, Range(0, 1)] public float MinRealtiveVelosity { get; private set; } = .1f;
    [field: SerializeField] public GameObject ExplosiveParticles { get; private set; }
    [field: SerializeField] public float ExplosiveForce { get; private set; } = 100;
    [field: SerializeField] public float ExplosiveRadius { get; private set; } = 10;
}