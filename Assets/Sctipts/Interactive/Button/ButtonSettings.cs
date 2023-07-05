using FinimenSniperC.Interactive;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Button")]
public class ButtonSettings : ScriptableObject
{
    [field: SerializeField] public Material Green { get; private set; }
    [field: SerializeField] public Material Red { get; private set; }
    [field: SerializeField] public Material Yellow { get; private set; }
    [field: SerializeField] public InvokeType InvokeType { get; private set; }
}