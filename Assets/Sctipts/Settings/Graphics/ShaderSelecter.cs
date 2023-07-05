using UnityEngine;

public class ShaderSelecter : MonoBehaviour
{
    private bool isPC;

    public bool IsPC
    {
        get
        {
            return isPC;
        }
    }

    public void UpdateShaders(bool isPC)
    {
        this.isPC = isPC;

        foreach (var renderer in FindObjectsOfType<SelectabelMaterialObject>())
        {
            renderer.SetMaterial(isPC);
        }

        PlayerPrefs.SetInt("UsePCShaders", isPC ? 1 : 0);
    }

    private void Start()
    {
        UpdateShaders(PlayerPrefs.GetInt("UsePCShaders") == 1 ? true : false);
    }
}