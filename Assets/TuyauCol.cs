using UnityEngine;

public class TuyauCol : MonoBehaviour
{
    [SerializeField]  Animation tuyauAnim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Vérifie si le collider entre en collision avec un objet ayant le tag "Player"
        {
            if (tuyauAnim != null)
            {
                tuyauAnim.Play(); // Joue l'animation du tuyau

                // Autres actions à effectuer lorsque le joueur entre en collision avec le tuyau
            }
        }
    }
}
