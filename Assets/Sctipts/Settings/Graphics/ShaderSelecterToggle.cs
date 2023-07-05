using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle), typeof(ShaderSelecter))]
public class ShaderSelecterToggle : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(GetComponent<ShaderSelecter>().UpdateShaders);
    }

    private void Start()
    {
        GetComponent<Toggle>().isOn = GetComponent<ShaderSelecter>().IsPC;
    }
}