using UnityEngine;

namespace FinimenSniperC.RollerBall
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private bool useTorque = true;

        [Space(15)]
        [SerializeField] private float movePower = 5;
        [SerializeField] private float maxAngularVelocity = 25;
        [SerializeField] private float jumpPower = 2;

        [Space(15)]
        [SerializeField] private float groundRayLength = 1f;

        [SerializeField] private LayerMask raycastMask;

        private QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.Ignore;

        private Rigidbody rigidbodyCurrent;

        public bool IsGround {get; private set;}

        private void Start()
        {
            rigidbodyCurrent = GetComponent<Rigidbody>();

            rigidbodyCurrent.maxAngularVelocity = maxAngularVelocity;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundRayLength, transform.position.z));
        }

        public void Move(Vector3 moveDirection, bool jump)
        {
            if (useTorque)
            {
                rigidbodyCurrent.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * movePower);
            }
            else
            {
                rigidbodyCurrent.AddForce(moveDirection * movePower);
            }

            if(Physics.Raycast(transform.position, -Vector3.up, groundRayLength, raycastMask, triggerInteraction))
            {
                IsGround = true;
            }
            else
            {
                IsGround = false;
            }

            if (IsGround && jump)
            {
                rigidbodyCurrent.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }

        public void MultiplyJump(float amount)
        {
            jumpPower *= amount;
        }

        public void MultiplySpeed(float amount)
        {
            movePower *= amount;
        }
    }
}