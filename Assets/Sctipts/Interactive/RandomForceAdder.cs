using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class RandomForceAdder : MonoBehaviour
{
    [SerializeField] private float force;

    private void Awake()
    {
        GetComponent<Rigidbody>()
            .AddForce(new Vector3(
            Random.Range(-force, force),
            Random.Range(-force, force),
            Random.Range(-force, force)));
    }
}