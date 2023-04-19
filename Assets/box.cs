using UnityEngine;

public class box : MonoBehaviour
{
    // Vitesse de déplacement de l'objet
    public float speed = 5f;

    // La position à partir de laquelle l'objet est considéré comme "hors-cadre"
    public float destroyPosition = -50f;

    void Update()
    {
        // Déplacer l'objet vers la gauche
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Si l'objet est sorti du cadre, le détruire
        if (transform.position.x < destroyPosition)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "mur2")
        {
            Destroy(gameObject);
        }
    }
}
