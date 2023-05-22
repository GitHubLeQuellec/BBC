using UnityEngine;

public class GrilleOutSide : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de déplacement de l'objet
    public float rotationSpeed = 180f; // Vitesse de rotation de l'objet
    public float destroyDelay = 2f; // Délai avant de détruire l'objet après l'avoir activé

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Appliquer une force initiale vers la droite pour propulser l'objet
        rb.AddForce(new Vector2(moveSpeed, 0f), ForceMode2D.Impulse);

        // Faire tourner l'objet sur lui-même
        rb.angularVelocity = rotationSpeed;

        // Détruire l'objet après le délai spécifié
        Destroy(gameObject, destroyDelay);
    }
}
