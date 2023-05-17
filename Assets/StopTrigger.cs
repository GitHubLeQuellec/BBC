using UnityEngine;

public class StopTrigger : MonoBehaviour
{
    [SerializeField] Rigidbody2D targetRigidbody; // Référence au Rigidbody que tu veux activer

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("coucou");

            // Récupère le Rigidbody du joueur
            Rigidbody2D playerRigidbody = collision.GetComponent<Rigidbody2D>();
            targetRigidbody.bodyType = RigidbodyType2D.Dynamic;
            //targetRigidbody.mass = 99999999;

            collision.GetComponent<Player_Commande>().moveSpeed = 0;
            collision.GetComponent<Player_Commande>().jumpForce = 0;
            

            // Arrête le mouvement du joueur en mettant sa vélocité à zéro
            //playerRigidbody.velocity = Vector2.zero;
        }
    }
}