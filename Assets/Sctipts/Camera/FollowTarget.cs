using Assets.Sctipts.Settings;
using UnityEngine;


namespace FinimenSniperC.CameraControllers
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform targetMove;
        [SerializeField] private Transform targetLook;

        [SerializeField] private CameraSettings settings;

        [SerializeField] private float roll;

        private Rigidbody targetRigibody;

        private Vector3 currentOffest;

        public Vector3 Offest { get { return currentOffest; } }
        public Transform TargetLook { get { return targetLook; } }
        public Transform TargetMove { get { return targetMove; } }
        public float SpeedBoost { get; set; } = 1;

        private void Awake()
        {
            targetRigibody = targetMove.GetComponent<Rigidbody>();
            currentOffest = settings.Offest;
        }

        private void LateUpdate()
        {
            if (!targetMove)
            {
                Destroy(this);
                return;
            }

            roll = targetRigibody.velocity.z * 5;

            transform.position = Vector3.Lerp(transform.position, targetMove.position + currentOffest, settings.Speed * SpeedBoost * Time.deltaTime);

            Vector3 direction = (targetLook.position - transform.position);
            
            Quaternion rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0,0, roll);

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, settings.Speed * SpeedBoost * Time.deltaTime);
        }

        public void SetTargetMove(Transform target)
        {
            if(target != null)
            {
                targetMove = target;
            }
        }

        public void SetTargetLook(Transform target)
        {
            if (target != null)
            {
                targetLook = target;
            }
        }

        public void SetOffest(Vector3 newOffets)
        {
            currentOffest = newOffets;
        }
    }
}
