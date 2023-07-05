using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Dan.Main;
using System.Linq;

public class Leaderbord : MonoBehaviour
{
    [SerializeField] List<Text> names = new List<Text>();
    [SerializeField] List<Text> scores = new List<Text>();

    [Space(25)]
    [SerializeField] private GameObject yourScore;
    [SerializeField] private Text yourScoreText;

    [SerializeField] private Color player;
    [SerializeField] private Color other;

    [Space(25)]
    [SerializeField, TextArea] private string publicLeaderbordKey = "2e3348600a90a7fe8e092095458017cce58a7aa75bfa0bf6c79f1208b6a52f90";

    private void Start()
    {
        GetLeaderbord();
    }

    public void GetLeaderbord(string currentPlayer = "")
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderbordKey, (massage) =>
        {
            int loopCount = massage.Length < names.Count? massage.Length : names.Count;
            //massage = massage.Reverse().ToArray();

            for (int i = 0; i < names.Count; i++)
            {
                names[i].text = "";
                scores[i].text = "";
            }

            for (int i = 0; i < loopCount; i++)
            {
                names[i].color = currentPlayer == massage[i].Username ? player : other;
                names[i].text = $"{i + 1}. {massage[i].Username}";

                float seconds = -massage[i].Score / 100;
                
                scores[i].text = $"{(int)(seconds / 60)}:{(int)(seconds % 60)}";

                if(currentPlayer == massage[i].Username)
                {
                    yourScore.gameObject.SetActive(true);
                    yourScoreText.text = $"{i + 1}st   {scores[i].text}";
                }
            }
        });
    }

    public void SetLeaderbordEntry(string username, int score)
    {
        Debug.Log($"Name{username} : {score}");

        LeaderboardCreator.UploadNewEntry(publicLeaderbordKey, username, -score, (massage) =>
        {
            GetLeaderbord(username);
        });
    }
}