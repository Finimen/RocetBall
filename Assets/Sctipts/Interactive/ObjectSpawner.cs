using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private Vector3 force;
    [SerializeField] private float reload = 3;
    [SerializeField] private bool enableToSpawn;

    private float timer;

    public void EnableToSpawn(bool enableToSpawn)
    {
        this.enableToSpawn = enableToSpawn;
    }

    private void Update()
    {
        if (!enableToSpawn)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= reload)
        {
            timer = 0;
            var spawned = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            if(spawned.GetComponent<Rigidbody>() != null )
            {
                spawned.GetComponent<Rigidbody>().AddForce(force);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(spawnPoint.position, spawnPoint.position + force);
    }
}