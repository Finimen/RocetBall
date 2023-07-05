using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class AlphaController : MonoBehaviour
    {
        [field: SerializeField] public Image Image { get; private set; }
        [field: SerializeField] public Text Text { get; private set; }

        private void Awake()
        {
            if(GetComponent<Image>() != null)
            {
                Image = GetComponent<Image>();
            }

            if(GetComponent<Text>() != null)
            {
                Text = GetComponent<Text>();
            }
        }
    }
}