using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab1 : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal_value;
    float vertical_value;

    private Vector2 aidepose;
    [SerializeField] GameObject aide;
    float range = 5;
    [SerializeField] float grabPower = 100;
    public GameObject aim;
    [SerializeField] float limitGrabByPlayer = 10;
    [SerializeField] float maxSpeed = 1; // Vitesse maximale autorisée
    [SerializeField] Collectible1 collectible1Script;

    [SerializeField] float raycastRange = 5f; // Ajout de la variable raycastRange

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collectible1Script = GameObject.FindObjectOfType<Collectible1>();
    }

    // Update is called once per frame
    void Update()
    {
        aim.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aim.transform.position = new Vector3(aim.transform.position.x, aim.transform.position.y, 0);
        horizontal_value = Input.GetAxis("Horizontal");
        vertical_value = Input.GetAxis("Vertical");

        Vector3 propulsionDir = (aim.transform.position - transform.position);
        propulsionDir = Vector3.Normalize(propulsionDir);
        Debug.DrawRay(transform.position, propulsionDir * range, Color.magenta, 0, false);

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, propulsionDir, range, LayerMask.GetMask("trouduc"));

        if (Input.GetMouseButton(1))
        {
            for (int i = 0; i < hits.Length; i++)
            {
                Debug.Log(hits[i].collider.name);
                Rigidbody2D rbRef = hits[i].transform.gameObject.GetComponent<Rigidbody2D>();
                if (rbRef.mass > limitGrabByPlayer)
                {
                    rbRef.AddForce(propulsionDir * grabPower*20 * Time.fixedDeltaTime);
                }
                else
                {
                    rbRef.velocity = propulsionDir * grabPower*20 * Time.fixedDeltaTime;
                    rbRef.velocity = new Vector2(Mathf.Clamp(rbRef.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rbRef.velocity.y, -maxSpeed, maxSpeed)); // Limite de vitesse
                }
            }


        }

        /*if (collectible1Script.IsCollected && Input.GetMouseButtonDown(1))
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, propulsionDir, range, LayerMask.GetMask("Plateform"));

            for (int i = 0; i < hits.Length; i++)
            {
                Debug.Log(hits[i].collider.name);
                Rigidbody2D rbRef = hits[i].transform.gameObject.GetComponent<Rigidbody2D>();
                if (rbRef.mass > limitGrabByPlayer)
                {
                    rb.velocity = -propulsionDir * grabPower * Time.fixedDeltaTime;
                }
                else
                {
                    rbRef.velocity = -propulsionDir * grabPower * Time.fixedDeltaTime;
                    rbRef.velocity = new Vector2(Mathf.Clamp(rbRef.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rbRef.velocity.y, -maxSpeed, maxSpeed)); // Limite de vitesse
                }
            }
        }
        */

    }
}

