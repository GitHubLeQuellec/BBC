using UnityEngine;

public class AnimTuyau : MonoBehaviour
{
    private Animator tuyauAnimator; // Référence à l'Animator du tuyau

    private void Start()
    {
        tuyauAnimator = GetComponent<Animator>(); // Obtient la référence à l'Animator attaché au tuyau
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") // Vérifie si le joueur entre dans le collider spécifié
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            tuyauAnimator.SetBool("Poke", true); // Active le booléen "Poke" dans l'Animator du tuyau
        }
    }
}
