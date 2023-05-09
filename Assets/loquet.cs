using UnityEngine;

public class loquet : MonoBehaviour
{
    // La position � laquelle figer l'objet
    public Vector3 freezePosition;

    void Start()
    {
        // D�sactiver la gravit� de l'objet pour �viter qu'il tombe
        GetComponent<Rigidbody>().useGravity = false;

        // D�finir la position de l'objet
        transform.position = freezePosition;

        // Verrouiller la rotation de l'objet
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
}
