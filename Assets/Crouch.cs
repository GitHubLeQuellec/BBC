using UnityEngine;

public class Crouch : MonoBehaviour
{
    public float crouchSpeed = 2f; // Vitesse de déplacement en position accroupie
    public float normalSpeed = 5f; // Vitesse de déplacement normale
    public Transform crouchCheck; // Transform du point de vérification de l'accroupissement
    public LayerMask groundLayer; // Layer du sol

    private bool isCrouching = false; // Indique si le joueur est actuellement accroupi
    private bool isGrounded = false; // Indique si le joueur est au sol
    private float playerHeight; // Hauteur du joueur

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHeight = GetComponent<BoxCollider2D>().size.y; // Hauteur du joueur basée sur le Collider
    }

    private void Update()
    {
        // Vérifier si le joueur est au sol
        isGrounded = Physics2D.OverlapCircle(crouchCheck.position, 0.2f, groundLayer);

        // Gérer l'entrée du joueur pour s'accroupir
        if (Input.GetKeyDown(KeyCode.C) && isGrounded)
        {
            isCrouching = !isCrouching; // Inverser l'état d'accroupissement

            if (isCrouching)
            {
                // S'accroupir
                rb.velocity = Vector2.zero;
                transform.localScale = new Vector3(1f, 0.5f, 1f); // Redimensionner le joueur en position accroupie
            }
            else
            {
                // Se relever
                transform.localScale = new Vector3(1f, 1f, 1f); // Redimensionner le joueur à sa taille normale
            }
        }

        // Gérer le déplacement horizontal
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (isCrouching)
        {
            // Déplacement en position accroupie
            rb.velocity = new Vector2(moveInput * crouchSpeed, rb.velocity.y);
        }
        else
        {
            // Déplacement normal
            rb.velocity = new Vector2(moveInput * normalSpeed, rb.velocity.y);
        }
    }
}
