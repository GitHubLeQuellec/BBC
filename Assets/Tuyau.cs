using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuyau : MonoBehaviour


{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        // Ajouter le tag "Player" au collider du joueur
        GameObject.FindGameObjectWithTag("Player").tag = "Player";
        animator = GetComponent<Animator>();
        animator.SetBool("Poke", false);

        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator not found on Tuyau!");
        }
        else
        {
            animator.SetBool("Poke", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Lancer l'animation "Poke"
            animator.SetBool("Poke", true);
            Debug.Log("jtepokeBB");
        }
    }
}
  
