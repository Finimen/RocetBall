using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompletedText : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Text>().text = $"{SceneManager.GetActiveScene().name} complteted!";
    }
}