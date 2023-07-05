using UnityEngine;

namespace Assets.Scripts.MarketSystem
{
    public class CionAnimator : MonoBehaviour
    {
        private float speed = 175;

        private new Transform transform;

        private void Awake()
        {
            transform = GetComponent<Transform>();
        }

        private void Update()
        {
            transform.Rotate(0, speed * Time.deltaTime, 0); 
        }
    }
}