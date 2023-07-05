using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class LanguageSelector : MonoBehaviour
    {
        private Language[] languages;

        private void Awake()
        {
            languages = Enum.GetValues(typeof(Language)) as Language[];

            var optioins = new System.Collections.Generic.List<TMPro.TMP_Dropdown.OptionData>();

            foreach (Language language in languages)
            {
                optioins.Add(new TMPro.TMP_Dropdown.OptionData(language.ToString()));
            }
        }

        private void Start()
        {
            GetComponent<Dropdown>().value = (int)FindObjectOfType<Translator>().Current;
        }

        public void SetLanguage(int id)
        {
            FindObjectOfType<Translator>().SetLanguage(languages[id]);
        }
    }
}