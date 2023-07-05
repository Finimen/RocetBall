using UnityEngine;

public class SelectLanguageCanvas : MonoBehaviour
{
    [SerializeField] private Canvas[] canvases;

    private void Awake()
    {
        SetActiveCanvases(PlayerPrefs.HasKey("Language"));
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