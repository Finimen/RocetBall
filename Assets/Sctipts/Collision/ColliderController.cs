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
using UnityEngine.Events;

namespace FinimenSniperC
{
    [DisallowMultipleComponent]
    internal class ColliderController : MonoBehaviour
    {
        [SerializeField] private bool checkIsPlayer;

        [Header("Trigger")]
        [SerializeField] private UnityEventCollider _OnTriggerEnter;

        [SerializeField] private UnityEventCollider _OnTriggerExit;

        [Header("Collision")]
        [SerializeField] private UnityEventCollision _OnCollisionEnter;

        [SerializeField] private UnityEventCollision _OnCollisionExit;

        private void OnTriggerEnter(Collider other)
        {
            if(checkIsPlayer && (other.tag != "Player"))
            {
                return;
            }

            if (_OnTriggerEnter != null)
            {
                _OnTriggerEnter.Invoke(other);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (checkIsPlayer && (other.tag != "Player"))
            {
                return;
            }

            if (_OnTriggerExit != null)
            {
                _OnTriggerExit.Invoke(other);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (checkIsPlayer && (other.gameObject.tag != "Player"))
            {
                return;
            }

            if (_OnCollisionEnter != null)
            {
                _OnCollisionEnter.Invoke(other);
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (checkIsPlayer && (other.gameObject.tag != "Player"))
            {
                return;
            }

            if (_OnCollisionEnter != null)
            {
                _OnCollisionExit.Invoke(other);
            }
        }
    }

    [System.Serializable] public class UnityEventFloat : UnityEvent<float>
    {

    }

    [System.Serializable]
    public class UnityEventCollision : UnityEvent<Collision>
    {

    }

    [System.Serializable]
    public class UnityEventCollider : UnityEvent<Collider>
    {

    }
}