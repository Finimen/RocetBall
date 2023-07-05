using UnityEngine;
using UnityEngine.UI;

public class LeaderbordUI : MonoBehaviour
{
    [SerializeField] private GameObject mobileInput;
    [field: SerializeField] public Button Close { get; private set; }
    [field: SerializeField] public GameObject LeaderbordView { get; private set; }

    public void Show()
    {
        mobileInput.SetActive(false);
        
        LeaderbordView.SetActive(true);
        Close.gameObject.SetActive(true);
    }
}