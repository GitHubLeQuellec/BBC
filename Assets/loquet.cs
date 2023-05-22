using UnityEngine;

public class loquet : MonoBehaviour
{
    // La position à laquelle figer l'objet
    public Vector3 freezePosition;
    private Vector3 initialPosition;
    [SerializeField]private bool isMoving = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x - initialPosition.x) > 0.001f)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            
        }
       
    }
}
