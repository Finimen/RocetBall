using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public void SetName(string name)
    {
        Debug.Log($"NAME {name}");
        PlayerPrefs.SetString("PlayerName", name);
    }

    private void Awake()
    {
        GetComponent<InputField>().text = PlayerPrefs.HasKey("PlayerName") ? PlayerPrefs.GetString("PlayerName") : "Player";
    }
}