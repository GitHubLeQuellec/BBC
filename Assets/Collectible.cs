using UnityEngine;

public class Collectible : MonoBehaviour
{
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
       Destroy(gameObject);
    }
}