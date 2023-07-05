using UnityEngine;

public class SelectabelMaterialObject : MonoBehaviour
{
    [SerializeField] private Material pc;
    [SerializeField] private Material mobile;

    private MeshRenderer meshRenderer;

    public void SetMaterial(bool isPC)
    {
        if (isPC)
        {
            meshRenderer.material = pc;
        }
        else
        {
            meshRenderer.material = mobile;
        }
    }

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
}