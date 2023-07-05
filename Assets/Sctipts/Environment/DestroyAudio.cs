using UnityEngine;

namespace FinimenSniperC.Audio
{
    public class DestroyAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource prefab;

        private void OnDestroy()
        {
            if (!gameObject.scene.isLoaded)
            {
                return;
            }
                
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}