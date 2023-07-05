using System;
using UnityEngine;
using UnityEngine.UI;

public class MassagePanel : MonoBehaviour
{
    [SerializeField] private Text massageText;

    [SerializeField] private Button accept;
    [SerializeField] private Button cancel;

    public void Initialize(string massage, Action onAccepted = null, Action onCanceled = null)
    {
        massageText.text = massage;

        if(onAccepted != null)
        {
            accept.onClick.AddListener(onAccepted.Invoke);
        }

        if(onCanceled != null)
        {
            cancel.onClick.AddListener(onCanceled.Invoke);
        }
    }

    public void SetButtonNames(string acceptName, string canselName)
    {
        accept.GetComponentInChildren<Text>().text = acceptName;
        cancel.GetComponentInChildren<Text>().text = canselName;
    }
}