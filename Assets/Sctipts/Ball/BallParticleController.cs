/*               
            ░███████╗██╗███╗░░██╗██╗██╗░░░░░██╗███████╗███╗░░██╗   ░██████╗███╗░░██╗██╗██████╗░███████╗██████╗░░
			░██╔════╝██║████╗░██║██║████░░████║██╔════╝████╗░██║   ██╔════╝████╗░██║██║██╔══██╗██╔════╝██╔══██╗░
			░███████╗██║██╔██╗██║██║██║░██░░██║█████╗░░██╔██╗██║   ╚█████╗░██╔██╗██║██║██████╔╝█████╗░░██████╔╝░
			░██╔════╝██║██║╚████║██║██║░░░░░██║██╔══╝░░██║╚████║   ░╚═══██╗██║╚████║██║██╔═══╝░██╔══╝░░██╔══██╗░
			░██║░░░░░██║██║░╚███║██║██║░░░░░██║███████╗██║░╚███║   ██████╔╝██║░╚███║██║██║░░░░░███████╗██║░░██║░
			░╚═╝░░░░░╚═╝╚═╝░░╚══╝╚═╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝   ╚═════╝░╚═╝░░╚══╝╚═╝╚═╝░░░░░╚══════╝╚═╝░░╚═╝░
____________________________________________________________________________________________________________________________________________
                █▀▀▄ █──█ 　 ▀▀█▀▀ █──█ █▀▀ 　 ░█▀▀▄ █▀▀ ▀█─█▀ █▀▀ █── █▀▀█ █▀▀█ █▀▀ █▀▀█ 
                █▀▀▄ █▄▄█ 　 ─░█── █▀▀█ █▀▀ 　 ░█─░█ █▀▀ ─█▄█─ █▀▀ █── █──█ █──█ █▀▀ █▄▄▀ 
                ▀▀▀─ ▄▄▄█ 　 ─░█── ▀──▀ ▀▀▀ 　 ░█▄▄▀ ▀▀▀ ──▀── ▀▀▀ ▀▀▀ ▀▀▀▀ █▀▀▀ ▀▀▀ ▀─▀▀
____________________________________________________________________________________________________________________________________________
*/
using UnityEngine;
using FinimenSniperC.RollerBall;

namespace FinimenSniperC
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Ball))]
    internal class BallParticleController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem moveParticles;
        [SerializeField] private ParticleSystem hitParticles;

        [SerializeField] private float rigidbodyVeclosityScaler = 2;

        [SerializeField] private float minRelativeVelocity = 1f;

        private ParticleSystem.EmissionModule emission;

        private Rigidbody rigidbodyCurrent;

        private void Awake()
        {
            rigidbodyCurrent = GetComponent<Rigidbody>();

            emission = moveParticles.emission;
        }

        private void Update()
        {
            if(rigidbodyCurrent.velocity.magnitude > .1f)
            {
                emission.enabled = true;

                emission.rateOverTime = rigidbodyCurrent.velocity.magnitude / rigidbodyVeclosityScaler;
            }
            else
            {
                emission.enabled = false;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            float relativeVelocity = other.relativeVelocity.magnitude;

            if (relativeVelocity > minRelativeVelocity && other.gameObject.GetComponent<Surface>() != null)
            {
                hitParticles.Play();
            }
        }
    }
}