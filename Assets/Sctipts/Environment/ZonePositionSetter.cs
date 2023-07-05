using FinimenSniperC.CameraControllers;
using FinimenSniperC.RollerBall;
using UnityEngine;

namespace FinimenSniperC
{
    public class ZonePositionSetter : MonoBehaviour
    {
        [SerializeField] private Transform cameraPosition;

        [SerializeField] private bool setOffest;

        [SerializeField] private float speedBoost = 2;

        private FollowTarget cameraController;

        private Transform lastTarget;
        private Vector3 lastOffest;

        private void Awake()
        {
            cameraController = FindObjectOfType<FollowTarget>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Ball>())
            {
                lastOffest = cameraController.Offest;
                lastTarget = cameraController.TargetMove;

                cameraController.SetOffest(Vector3.zero);
                cameraController.SetTargetMove(cameraPosition);

                cameraController.SpeedBoost = speedBoost;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<Ball>())
            {
                cameraController.SetTargetMove(lastTarget);

                if (setOffest)
                {
                    cameraController.SetOffest(cameraController.transform.position - other.transform.position);
                }
                else 
                {
                    cameraController.SetOffest(lastOffest);
                }

                cameraController.SpeedBoost = 1;
            }
        }

        private void OnDisable()
        {
            cameraController.SetOffest(lastOffest);
        }
    }
}