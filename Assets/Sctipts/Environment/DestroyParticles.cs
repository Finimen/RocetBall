using UnityEngine;

namespace FinimenSniperC.ParticlesSsystem
{
    public class DestroyParticles : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;

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