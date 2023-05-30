using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Commande : MonoBehaviour
{
    public float moveSpeed = 10f; // vitesse de déplacement
    public float jumpForce = 10f; // force de saut
    public Transform groundCheck; // objet qui vérifie si le joueur touche le sol
    public LayerMask groundLayer;
    public LayerMask PlatRepuls;
    public LayerMask GrabPlat; // couche du sol

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isCrouching = false;
    private bool isJumping = false;
    private float originalColliderHeight;
    private Vector2 originalColliderOffset;
    private CapsuleCollider2D playerCollider;
    Animator Anim;


    public CapsuleCollider2D collider1; // Référence au premier collider
    public CapsuleCollider2D collider2; // Référence au deuxième collider


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3;
        Anim = GetComponent<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        originalColliderHeight = playerCollider.size.y;
        originalColliderOffset = playerCollider.offset;
        collider2.enabled = false;
        collider1.enabled = true;
    }

    void Update()
    {
        // vérifie si le joueur touche le sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer | GrabPlat | PlatRepuls);

        // déplacement horizontal
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Mettre à jour la variable Run
        bool shouldRun = (Mathf.Abs(rb.velocity.x) != 0 || Mathf.Abs(moveInput) > 0) && isCrouching == false && isGrounded == true;

        // Mettre à jour l'animation IsRunning
        Anim.SetBool("IsRunning", shouldRun);

        if (isCrouching)
        {
            collider1.enabled = false;
            collider2.enabled = true;
            Anim.SetBool("Crouching", true);
        }
        else
        {
            collider1.enabled = true;
            collider2.enabled = false;
            Anim.SetBool("Crouching", false);
        }

        // Turn
        if (moveInput != 0)
        {
            transform.localScale = new Vector2(Mathf.Sign(moveInput), 1f);
        }

        if (isGrounded)
        {
            Anim.SetBool("JumpLoop", false);
        }
        else if (isGrounded == false && Anim.GetBool("isJumping") == false)
        {
            Anim.SetBool("JumpLoop", true);
        }

        if (isGrounded && Anim.GetBool("JumpLoop") == false)
        {
            Anim.SetBool("Roost", true);
        }
        else
        {
            Anim.SetBool("Roost", false);
        }

        // saut
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Anim.SetBool("isJumping", true);
            
        }
        if (isJumping && rb.velocity.y < 0)
        {
            Anim.SetBool("isJumping", false);
            Anim.SetBool("JumpLoop", true);
            isJumping = false;
        }

        // accroupissement
        if (isGrounded && Input.GetKeyDown(KeyCode.S) && !isCrouching)
        {
            isCrouching = true;
            playerCollider.size = new Vector2(playerCollider.size.x, originalColliderHeight / 2f);
            playerCollider.offset = new Vector2(playerCollider.offset.x, originalColliderOffset.y - originalColliderHeight / 4f);
        }
        else if (isCrouching && (Input.GetKeyUp(KeyCode.S) || !isGrounded))
        {
            // Vérifier s'il y a un collider au-dessus du joueur
            bool hasCeilingCollider = Physics2D.Raycast(transform.position, Vector2.up, originalColliderHeight / 1f, groundLayer | GrabPlat | PlatRepuls);

            if (!hasCeilingCollider)
            {
                isCrouching = false;
                playerCollider.size = new Vector2(playerCollider.size.x, originalColliderHeight);
                playerCollider.offset = originalColliderOffset;
            }
        }
    }
}
