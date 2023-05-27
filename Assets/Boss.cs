using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject forkPrefab;
    public Transform spawnPoint;
    public float moveSpeed = 0f;
    public float forkSpawnRate = 2f;
    public Transform player;

    private float forkSpawnTimer = 0f;

    private void Update()
    {
        //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        forkSpawnTimer += Time.deltaTime;
        if (forkSpawnTimer >= forkSpawnRate)
        {
            SpawnFork();
            forkSpawnTimer = 0f;
        }
    }

    private void SpawnFork()
    {
        Vector2 direction = (player.position - spawnPoint.position).normalized;
        GameObject fork = Instantiate(forkPrefab, spawnPoint.position, Quaternion.identity);

        Rigidbody2D forkRigidbody = fork.GetComponent<Rigidbody2D>();
        forkRigidbody.velocity = direction * 10f;
    }
}
