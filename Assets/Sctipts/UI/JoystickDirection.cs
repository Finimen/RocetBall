using UnityEngine;

namespace Assets.Scripts 
{
    public class JoystickDirection : MonoBehaviour
    {
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private bool useStart;

        private Joystick joystick;
        private Quaternion startRotation;

        private void Awake()
        {
            joystick = FindObjectOfType<Joystick>();
            startRotation = transform.rotation;
        }

        private void Update()
        {
            if (useStart)
            {
                transform.rotation = startRotation * rigidbody.rotation;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, (Mathf.Clamp(rigidbody.velocity.x, 0, 1) + Mathf.Clamp(rigidbody.velocity.y, 0, 1)) * 180);
            }
        }
    }
}