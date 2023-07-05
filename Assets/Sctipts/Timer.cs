using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float seconds;

    [SerializeField] private Text text;

    private void Update()
    {
        seconds += Time.deltaTime;

        text.text = $"{(int)(seconds / 60)}:{(int)(seconds % 60)}";
    }

    public int GetTime()
    {
        enabled = false;

        return (int)(seconds * 100);
    }
}