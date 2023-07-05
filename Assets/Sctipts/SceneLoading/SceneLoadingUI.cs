using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FinimenSniperC.UI
{
    public class SceneLoadingUI : MonoBehaviour
    {
        [SerializeField] private int sceneId;
        [SerializeField] private float amount;

        private Image progress;

        private void Start ()
        {
            StartCoroutine(LoadNextScene());
        }

        private IEnumerator LoadNextScene()
        {
            AsyncOperation loading = SceneManager.LoadSceneAsync(sceneId, LoadSceneMode.Single);

            while (!loading.isDone)
            {
                amount = loading.progress;

                progress.fillAmount = loading.progress;

                yield return null;
            }
        }
    }
}