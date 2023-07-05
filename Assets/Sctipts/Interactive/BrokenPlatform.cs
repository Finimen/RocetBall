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
using System.Collections;

namespace FinimenSniperC.Interactive
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody), typeof(ColliderController))]
    internal class BrokenPlatform : MonoBehaviour
    {
        [SerializeField] private float delay = 1;

        [SerializeField] private float minRelativeVelocity = 1;

        [SerializeField] private float health = 5;

        private Rigidbody currentRigidbody;

        private float totalDamage;

        private bool damageEnabled;

        private void Awake()
        {
            currentRigidbody = GetComponent<Rigidbody>();

            currentRigidbody.useGravity = false;

            currentRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        private void Start()
        {
            StartCoroutine(DamageEnable());
        }

        private IEnumerator DamageEnable()
        {
            yield return new WaitForSeconds(1);

            damageEnabled = true;
        }

        public void OnPlayerEnter(Collision other)
        {
            if (!damageEnabled)
            {
                return;
            }

            float relativeVelocity = other.relativeVelocity.magnitude;

            if(relativeVelocity > minRelativeVelocity)
            {
                totalDamage += relativeVelocity;

                if(totalDamage > health)
                {
                    StartCoroutine(Break());
                }
            }
        }

        public void Breack()
        {
            StartCoroutine(Break());
        }

        private IEnumerator Break()
        {
            yield return new WaitForSeconds(delay);

            currentRigidbody.useGravity = true;

            currentRigidbody.constraints = RigidbodyConstraints.None;
        }
    }
}