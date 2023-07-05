using UnityEngine;

public class TextTranslator : MonoBehaviour
{
    [SerializeField] private Sentence[] sentences;

    private void Start()
    {
        var translator = FindObjectOfType<Translator>(true);
        translator.OnLanguageChanged += SetText;

        SetText(translator.Current);
    }

    private void SetText(Language language)
    {
        foreach (var sentence in sentences)
        {
            if(sentence.Language == language)
            {
                sentence.Text.SetActive(true);
            }
            else
            {
                sentence.Text.SetActive(false);
            }
        }
    }
}