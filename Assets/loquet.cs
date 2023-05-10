using UnityEngine;

public class loquet : MonoBehaviour
{
    // La position à laquelle figer l'objet
    public Vector3 freezePosition;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Mathf.Abs(rb.velocity.x) > 10f)
                transform.rotation = Quaternion.Euler(0, 0, 40);
    }
}
