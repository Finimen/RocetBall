using Tayx.Graphy;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class GraphyToggle : MonoBehaviour
{
    private GraphyManager graphy;

    private void Awake()
    {
        graphy = FindObjectOfType<GraphyManager>();

        GetComponent<Toggle>().onValueChanged.AddListener(UpdateGraphy);
    }

    private void UpdateGraphy(bool active)
    {
        graphy.gameObject.SetActive(active);
    }
}