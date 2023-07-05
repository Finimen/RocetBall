using System;
using UnityEngine;

public class Translator : MonoBehaviour
{
    [field: SerializeField] public Language Current { get; private set; }

    [SerializeField, Space(25)] private KeySentence[] keySentences;

    public event Action<Language> OnLanguageChanged;

    private void Awake()
    {
        Current = (Language)SaveSystem.LoadInt("Language");
    }

    public void SetLanguage(Language language)
    {
        Current = language;

        OnLanguageChanged?.Invoke(language);

        SaveSystem.SaveInt("Language", (int)Current);
    }

    [Serializable]
    public class KeySentence
    {
        [field:SerializeField] public string Key { get; private set; }

        [field: SerializeField] public Sentence[] Sentences { get; private set; }
    }
}