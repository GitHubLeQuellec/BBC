using UnityEngine;

public class GrilleOutSide : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de d�placement de l'objet
    public float rotationSpeed = 180f; // Vitesse de rotation de l'objet
    public float destroyDelay = 2f; // D�lai avant de d�truire l'objet apr�s l'avoir activ�

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Appliquer une force initiale vers la droite pour propulser l'objet
        rb.AddForce(new Vector2(moveSpeed, 0f), ForceMode2D.Impulse);

        // Faire tourner l'objet sur lui-m�me
        rb.angularVelocity = rotationSpeed;

        // D�truire l'objet apr�s le d�lai sp�cifi�
        Destroy(gameObject, destroyDelay);
    }
}
