using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject forkPrefab;
    public Transform spawnPoint;
    public Transform player;
    [SerializeField] Collider2D ZgegCol;

    public void SpawnFork()
    {
        Vector2 direction = (player.position - spawnPoint.position).normalized;
        GameObject fork = Instantiate(forkPrefab, spawnPoint.position, Quaternion.identity);

        Rigidbody2D forkRigidbody = fork.GetComponent<Rigidbody2D>();
        forkRigidbody.velocity = direction * 10f;
    }
    public void Zgeging()
    {

    }
}
