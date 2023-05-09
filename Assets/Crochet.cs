using UnityEngine;

public class Crochet : MonoBehaviour
{
    // Vitesse de d�placement de l'objet
    public float speed = 5f;

    // La position � partir de laquelle l'objet est consid�r� comme "hors-cadre"
    public float destroyPosition = -50f;



    // La position o� t�l�porter l'objet
    public Vector3 teleportPosition = new Vector3(94f, -2.6f, 0f);

    void Update()
    {
        // D�placer l'objet vers la gauche
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Si l'objet est sorti du cadre, le t�l�porter � la position sp�cifi�e
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

