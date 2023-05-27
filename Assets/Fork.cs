using UnityEngine;

public class Fork : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float lifespan = 3f;

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BossCollider"))
        {
            Rigidbody2D forkRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (forkRigidbody != null)
            {
                forkRigidbody.simulated = false;
                Destroy(gameObject, lifespan);
                Debug.Log("mort1");
            }
        }
        if (collision.gameObject.CompareTag("Plateform"))
        {
            Destroy(gameObject, lifespan);
            Debug.Log("mort2");
        }
        if (collision.gameObject.CompareTag("player"))
        {
            Destroy(gameObject, lifespan);
            Debug.Log("mort3");
        }
    }
}
