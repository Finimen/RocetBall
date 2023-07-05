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
using System;
using System.Collections.Generic;

namespace FinimenSniperC.Interactive
{
    [DisallowMultipleComponent]
    internal class WindZone : MonoBehaviour, IPlayerEnterable, IPlayerExitable
    {
        [SerializeField] private Transform forceCenter;

        [SerializeField] private Vector3 forceVector;

        [Range(0,3)]
        [SerializeField] private float distancePow = 1;

        [SerializeField] private bool forceEnabled = true;

        private HashSet<Rigidbody> rigidbodiesEntered = new HashSet<Rigidbody>();

        public bool ForceEnabled { get { return forceEnabled; } }

        public Action<bool> OnForceEnabledChange;

        private void Update()
        {
            if (rigidbodiesEntered.Count > 0)
            {
                if (forceCenter)
                {
                    foreach(Rigidbody rigidbody in rigidbodiesEntered)
                    {
                        rigidbody.AddForce(forceVector * rigidbody.mass * Time.deltaTime * 72
                            / Mathf.Pow(Vector3.Distance(rigidbody.transform.position, forceCenter.position), distancePow));
                    }
                }
                else
                {
                    foreach (Rigidbody rigidbody in rigidbodiesEntered)
                    {
                        rigidbody.AddForce(forceVector * rigidbody.mass * Time.deltaTime * 72);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            Gizmos.DrawLine(forceCenter.position, forceCenter.position + forceVector / 10);
        }

        public void OnPlayerEnter(Collider other)
        {
            if (!forceEnabled || !other.GetComponent<Rigidbody>())
            {
                return;
            }

            rigidbodiesEntered.Add(other.GetComponent<Rigidbody>());
        }

        public void OnPlayerExit(Collider other)
        {
            if (!other.GetComponent<Rigidbody>())
            {
                return;
            }

            rigidbodiesEntered.Remove(other.GetComponent<Rigidbody>());
        }

        public void SetForceEnabled(bool forceEnabled)
        {
            this.forceEnabled = forceEnabled;

            if(OnForceEnabledChange != null)
            {
                OnForceEnabledChange.Invoke(forceEnabled);
            }
        }
    }
}