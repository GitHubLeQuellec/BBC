using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Code � ex�cuter lorsque le joueur entre en collision avec le collectible
            Collect();
        }
    }

    private void Collect()
    {
        // Code � ex�cuter lorsque le collectible est collect�
       Destroy(gameObject);
    }
}