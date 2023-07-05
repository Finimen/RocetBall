using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadLevelMobileButton : MonoBehaviour
{
    [SerializeField] private Button loadLevelMobile;
    [SerializeField] private UnityEvent onButtonClicked;

    public void OnTriggerEntered(Collider other)
    {
        if (other.tag == "Player")
        {
            loadLevelMobile.onClick.AddListener(InvokeEvent);
        }
    }

    public void OnTriggerExited(Collider other)
    {
        if(other.tag == "Player")
        {
            loadLevelMobile.onClick.RemoveListener(InvokeEvent);
        }
    }

    private void InvokeEvent()
    {
        onButtonClicked.Invoke();
    }
}