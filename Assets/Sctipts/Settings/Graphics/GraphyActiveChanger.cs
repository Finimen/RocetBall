using Tayx.Graphy;
using UnityEngine;

public class GraphyActiveChanger : MonoBehaviour
{
    private void Awake()
    {
        if(FindObjectOfType<GraphyManager>(true) != null)
        {
            FindObjectOfType<GraphyManager>(true).gameObject.SetActive(true);
        }
    }
}