using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSaut : MonoBehaviour
{
    private Animator animator;
    private bool isJumping = false;
    private bool isGrounded = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        //Debug.Log(isGrounded);

        if (isGrounded)
        {
            // Le joueur est sur le sol
            //Debug.Log("isGrounded");
            isGrounded = true;
        }
        else
        {
            // Le joueur n'est pas sur le sol
            //Debug.Log("PasGrounded");
            isGrounded = false;
        }

        // Déclencher le saut si le joueur appuie sur la touche de saut et qu'il est sur le sol
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            animator.SetTrigger("Jump_Start");
            //Debug.Log("Saute");
            isGrounded = true;
        }

        // Jouer l'animation de saut en continu tant que le joueur est en l'air
        if (isJumping && !isGrounded)
        {
            animator.SetTrigger("Jump_Loop");
            //Debug.Log("Vol");
            isGrounded = false;
        }
        else
        {
            //animator.SetBool("Jump_Loop", false);
            //Debug.Log("volpas");
        }

        // Terminer l'animation de saut lorsque le joueur touche le sol
        if (isJumping && isGrounded)
        {
            isJumping = false;
            animator.SetTrigger("Jump_End");
            //Debug.Log("attéri");
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifier si le joueur touche le sol
        if (collision.CompareTag("Platform")|| collision.CompareTag("PlatRepuls") || collision.CompareTag("GrabPlat"))
        {
            isGrounded = true;
            
        }
    }

    
}
