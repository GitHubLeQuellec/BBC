using UnityEngine;

public class loquet : MonoBehaviour
{
    // La position à laquelle figer l'objet
    public Vector3 freezePosition;

    void Start()
    {
        // Désactiver la gravité de l'objet pour éviter qu'il tombe
        GetComponent<Rigidbody>().useGravity = false;

        // Définir la position de l'objet
        transform.position = freezePosition;

        // Verrouiller la rotation de l'objet
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
}
