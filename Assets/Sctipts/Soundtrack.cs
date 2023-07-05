using UnityEngine;

namespace Assets.Scripts
{
    public class Soundtrack : MonoBehaviour
    {
        [SerializeField] private AudioClip[] sounds;

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if(!audioSource.isPlaying)
            {
                audioSource.clip = sounds[Random.Range(0, sounds.Length)];
                audioSource.Play();
            }
        }
    }
}