using UnityEngine;

public class FakeGravityDealer : MonoBehaviour
{
    [SerializeField] private float gravity = .1f;

    private int enteredCount;

    private void Update()
    {
        if (enteredCount <= 0)
        {
            transform.position -= Vector3.up * gravity * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            enteredCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger)
        {
            enteredCount--;
        }
    }
}