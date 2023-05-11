using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Commande : MonoBehaviour
{
    public float moveSpeed = 10f; // vitesse de déplacement
    public float jumpForce = 10f; // force de saut
    public Transform groundCheck; // objet qui vérifie si le joueur touche le sol
    public LayerMask groundLayer; // couche du sol

    private Rigidbody2D rb;
    private bool isGrounded = false;
    Animator Anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3;
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        // vérifie si le joueur touche le sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // déplacement horizontal
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Turn
        if (moveInput != 0)
        {
            if (moveInput > 0)
            {
                transform.localScale = new Vector2(1f, 1f); // tourne le personnage à droite
            }
            else
            {
                transform.localScale = new Vector2(-1f, 1f); // tourne le personnage à gauche
            }
        }

        if (isGrounded)
        {
            Anim.SetBool("JumpLoop", false);
        }
        else if (isGrounded==false && Anim.GetBool("isJumping") == false)
        {
            Anim.SetBool("JumpLoop", true);
        }

        if(isGrounded && Anim.GetBool("JumpLoop")==false )
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
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Anim.SetBool("isJumping",true);
        }
        if (Anim.GetBool("isJumping")==true && rb.velocity.y < 0)
        {
            Anim.SetBool("isJumping", false);
            Anim.SetBool("JumpLoop", true);
        }

    }
}