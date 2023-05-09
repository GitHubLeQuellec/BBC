using UnityEngine;

public class Crochet : MonoBehaviour
{
    // Vitesse de déplacement de l'objet
    public float speed = 5f;

    // La position à partir de laquelle l'objet est considéré comme "hors-cadre"
    public float destroyPosition = -50f;



    // La position où téléporter l'objet
    public Vector3 teleportPosition = new Vector3(94f, -2.6f, 0f);

    void Update()
    {
        // Déplacer l'objet vers la gauche
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Si l'objet est sorti du cadre, le téléporter à la position spécifiée
        if (transform.position.x < destroyPosition)
        {
            transform.position = teleportPosition;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "mur2")
        {
            transform.position = teleportPosition;
        }
    }
}

