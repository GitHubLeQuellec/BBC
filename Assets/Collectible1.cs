using UnityEngine;

public class Collectible1 : MonoBehaviour
{
    public bool IsCollected = false;
    public float propulsionForce = 10f;
    public float raycastRange = 5f;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Code à exécuter lorsque le joueur entre en collision avec le collectible
            Collect();
        }
    }

    private void Collect()
    {
        // Code à exécuter lorsque le collectible est collecté
        IsCollected = true;
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        if (IsCollected && Input.GetMouseButtonDown(1))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePosition - (Vector2)transform.position, raycastRange);

            if (hit.collider != null && hit.collider.CompareTag("Platform"))
            {
                Rigidbody2D playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
                Vector2 direction = (Vector2)transform.position - hit.point;
                playerRigidbody.AddForce(direction.normalized * propulsionForce, ForceMode2D.Impulse);
            }
        }
    }
}
