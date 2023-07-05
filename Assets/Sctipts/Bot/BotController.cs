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

namespace FinimenSniperC
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody),typeof(Collider))]
    internal class BotController : MonoBehaviour
    {
        public System.Action OnGetDamage;

        [SerializeField] private RobotSettings settings;

        [SerializeField] private float totalDamage;

        [SerializeField] private float maxDamage;

        [SerializeField] private bool isDamaged;
        [SerializeField] private bool isExplosive;

        private MeshRenderer botMeshRenderer;

        private bool damageEnterEnabled;

        private void Awake()
        {
            botMeshRenderer = GetComponentInChildren<MeshRenderer>();
        }

        private void Start()
        {
            maxDamage *= Random.Range(.5f, 2);

            StartCoroutine(DamageEnterEnable());
        }

        private IEnumerator DamageEnterEnable()
        {
            yield return new WaitForSeconds(1);

            damageEnterEnabled = true;
        }

        private void OnDrawGizmos()
        {
            if (isDamaged)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }

            Gizmos.DrawCube(transform.position, new Vector3(.75f, .75f, .75f));
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!damageEnterEnabled)
            {
                return;
            }

            float relativeVelocity = other.relativeVelocity.magnitude;

            if (relativeVelocity >= settings.MinRealtiveVelosity)
            {
                GetDamage(relativeVelocity);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!damageEnterEnabled)
            {
                return;
            }

            if (other.gameObject.GetComponent<Interactive.WindZone>())
            {
                GetDamage(settings.MinRealtiveVelosity);
            }
        }

        public void GetDamage(float damageEnter = 0)
        {
            totalDamage += damageEnter;

            if (!isDamaged)
            {
                isDamaged = true;

                StartCoroutine(SetDamagedColor());

                if (OnGetDamage != null)
                {
                    OnGetDamage.Invoke();
                }

                if (!isExplosive)
                {
                    if (settings.CoinsDropChanse > Random.Range(0f, 1f))
                    {
                        Instantiate(settings.Coin, transform.position, Quaternion.identity);
                    }

                    return;
                }

                Instantiate(settings.ExplosiveParticles, transform.position, Quaternion.identity);

                foreach (var collider in Physics.OverlapSphere(transform.position, settings.ExplosiveRadius))
                {
                    if (collider.GetComponent<Rigidbody>())
                    {
                        collider.GetComponent<Rigidbody>().AddExplosionForce(settings.ExplosiveForce *
                            collider.GetComponent<Rigidbody>().mass, transform.position, settings.ExplosiveRadius);
                    }
                }
            }
        }

        private IEnumerator SetDamagedColor()
        {
            while (true)
            {
                yield return null;

                botMeshRenderer.material.color = Color.Lerp(botMeshRenderer.material.color, settings.DamagedColor, Time.deltaTime);
            }
        }
    }
}