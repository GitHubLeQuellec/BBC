using UnityEngine;

public class Fork : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float lifespan = 0.3f;
    [SerializeField] private GameObject Player;
    private Rigidbody2D rb;
    Vector2 direction; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = (Player.transform.position - transform.position);
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        //transform.rotation = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("BossCollider"))
        {
            Rigidbody2D forkRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (forkRigidbody != null)
            {
                forkRigidbody.simulated = false;
                Destroy(gameObject, lifespan);
                Debug.Log("mort1");
            }
        }*/
        if (collision.gameObject.CompareTag("Platform"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("mort2");
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("mort3");
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("fourche"))
        {
            Destroy(gameObject);
        }
    }
}
