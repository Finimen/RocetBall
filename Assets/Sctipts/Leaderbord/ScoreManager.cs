using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private string playerName;

    [SerializeField] private int playerScore;

    public UnityEvent<string, int> OnScoreSumbited;

    public void SubmitScore()
    {
        OnScoreSumbited?.Invoke(playerName, FindObjectOfType<Timer>().GetTime());
    }

    public void SetTime(int toScore)
    {
        playerScore = toScore;
    }

    private void Awake()
    {
        playerName = PlayerPrefs.HasKey("PlayerName") ? PlayerPrefs.GetString("PlayerName") : "Player";
        Debug.Log($"NAME {playerName}");
    }
}