using UnityEngine;
using UnityEngine.UI;

public class BlomUser : MonoBehaviour
{
    [SerializeField] private PostProcessor postProcessor;
    [SerializeField] private bool useBloom;

    private void Awake()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(UpdateBloom);
    }

    private void Start()
    {
        UpdateBloom(useBloom);
    }

    private void UpdateBloom(bool active)
    {
        postProcessor.Settings.BloomEnabled = active;
    }
}