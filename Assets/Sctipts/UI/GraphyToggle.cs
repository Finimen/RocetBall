using UnityEngine;
using UnityEngine.UI;

public class GraphyToggle : MonoBehaviour
{
    [SerializeField] private Toggle toggle;

    [SerializeField] private GameObject prefab;

    private GameObject current;

    private void Awake()
    {
        toggle.onValueChanged.AddListener(UpdateGraphy);

        UpdateGraphy(true);
    }

    private void UpdateGraphy(bool active)
    {
        if (active)
        {
            current = Instantiate(prefab);
        }
        else
        {
            Destroy(current);
        }
    }
}