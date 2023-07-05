using UnityEngine;

public class InputNameCanvas : MonoBehaviour
{
    [SerializeField] private Canvas[] canvases;

    private void Awake()
    {
        SetActiveCanvases(PlayerPrefs.HasKey("PlyaerName"));
    }

    public void SetActiveCanvases(bool isSaved)
    {
        gameObject.SetActive(!isSaved);

        foreach (var canvas in canvases)
        {
            canvas.enabled = isSaved;
        }
    }
}