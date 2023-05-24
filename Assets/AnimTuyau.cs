using UnityEngine;

public class AnimTuyau : MonoBehaviour
{
    private Animator tuyauAnimator; // R�f�rence � l'Animator du tuyau

    private void Start()
    {
        tuyauAnimator = GetComponent<Animator>(); // Obtient la r�f�rence � l'Animator attach� au tuyau
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") // V�rifie si le joueur entre dans le collider sp�cifi�
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            tuyauAnimator.SetBool("Poke", true); // Active le bool�en "Poke" dans l'Animator du tuyau
        }
    }
}
