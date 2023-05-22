using UnityEngine;

public class CageLoquet : MonoBehaviour
{
    [SerializeField] private GameObject objectToDelete; // L'objet � supprimer lorsque cet objet bouge
    [SerializeField] private GameObject cageOuverte; // L'objet "CageOuverte" � faire appara�tre
    [SerializeField] private GameObject cageFermee; // L'objet "9" � faire dispara�tre
    [SerializeField] private AudioSource Son; // Composant AudioSource pour le son
    [SerializeField] private GameObject BoxCol; // Le BoxCol

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cageOuverte.SetActive(false);
    }

    void Update()
    {
        if (rb.velocity.magnitude > 1f)
        {
            if (objectToDelete != null)
            {
                Destroy(objectToDelete);
                Destroy(cageFermee);
                Destroy(BoxCol);
                cageOuverte.SetActive(true);

                if (Son != null)
                {
                    Son.Play();
                }
            }
        }
    }
}
