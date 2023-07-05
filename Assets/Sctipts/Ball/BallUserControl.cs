using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace FinimenSniperC.RollerBall
{
    public enum ControlsType
    {
        PC = 0,
        Mobile = 1,
    }

    [DisallowMultipleComponent]
    [RequireComponent(typeof(Ball))]
    public class BallUserControl : MonoBehaviour
    {
        [SerializeField] private ControlsType controls = ControlsType.PC;

        [Header("PC")]
        [SerializeField] private string horizontalAxisName = "Horizontal";
        [SerializeField] private string verticalAxisName = "Vertical";
        [SerializeField] private string jumpButtonName = "Jump";

        [Header("Android")]
        [SerializeField] private FixedJoystick joystick;
        [SerializeField] private UnityEngine.UI.Button jumpButton;

        private Ball ball;

        private Transform cameraMain;
        
        private Vector3 move;
        private Vector3 camForward;
        
        private bool jump;

        private void Awake()
        {
            ball = GetComponent<Ball>();

            cameraMain = FindObjectOfType<Camera>().transform;
            
            if(controls == ControlsType.Mobile)
            {
               jumpButton.onClick.AddListener(() => jump = true);
            }
        }

        private void Update()
        {
            UpdateInput();
        }

        private void FixedUpdate()
        {
            MoveBall();
        }

        private void UpdateInput()
        {
            Vector2 inputVector = Vector2.zero;

            switch (controls)
            {
                case ControlsType.PC:
                    inputVector = UsePCInput();
                    break;
                case ControlsType.Mobile:
                    inputVector = UseMobileInput();
                    break;
            }
            
            camForward = Vector3.Scale(cameraMain.forward, new Vector3(1, 0, 1)).normalized;
            move = (inputVector.x * camForward + inputVector.y * cameraMain.right).normalized;
        }

        private Vector2 UsePCInput()
        {
            float horizontal = Input.GetAxis(horizontalAxisName);
            float vertical = Input.GetAxis(verticalAxisName);
            
            jump = Input.GetKeyDown(KeyCode.Space);

            return new Vector2(vertical, horizontal);
        }

        private Vector2 UseMobileInput()
        {
            return  new Vector2(joystick.Direction.y, joystick.Direction.x);
        }

        private void MoveBall()
        {
            ball.Move(move, jump);

            jump = false;
        }
    }
}