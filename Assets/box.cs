using UnityEngine;

public class box : MonoBehaviour
{
    // Vitesse de d�placement de l'objet
    public float speed = 5f;

    // La position � partir de laquelle l'objet est consid�r� comme "hors-cadre"
    public float destroyPosition = -50f;

    void Update()
    {
        // D�placer l'objet vers la gauche
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Si l'objet est sorti du cadre, le d�truire
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
