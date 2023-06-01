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
    private bool canRepuls = true;
    [SerializeField] Animator Anim;

    [SerializeField] float raycastRange = 5f; // Ajout de la variable raycastRange
    public Camera cam;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        collectible1Script = GameObject.FindObjectOfType<Collectible1>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        aim.transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
        aim.transform.position = new Vector3(aim.transform.position.x, aim.transform.position.y, 0);
        horizontal_value = Input.GetAxis("Horizontal");
        vertical_value = Input.GetAxis("Vertical");

        Vector3 propulsionDir = (aim.transform.position - transform.position);
        propulsionDir = Vector3.Normalize(propulsionDir);
        Debug.DrawRay(transform.position, propulsionDir * range, Color.magenta, 0, false);

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, propulsionDir, range, LayerMask.GetMask("fourche", "PlatRepuls"));
        //, "PlatRepuls")
        
        
           
            //if (spriteRenderer != null)
           // {
                // Utilisez spriteRenderer pour effectuer des opérations sur le sprite de l'objet "fourche"
                // Par exemple, vous pouvez accéder à spriteRenderer.sprite pour obtenir le sprite actuel de l'objet
                // Ou utilisez spriteRenderer.flipX pour inverser le sprite horizontalement

                 // Exemple: Inverser le sprite horizontalement
           // }

            if (collectible1Script.IsCollected && Input.GetMouseButton(1) && canRepuls)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                    SpriteRenderer spriteRenderer = hits[i].transform.gameObject.GetComponentInChildren<SpriteRenderer>();
                    if (hits[i].transform.gameObject.layer == LayerMask.NameToLayer("fourche"))
                {

                    hits[i].transform.gameObject.GetComponent<Fork>().enabled = false;
                    hits[i].transform.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
                    spriteRenderer.flipX = true;
                Debug.Log(hits[i].collider.name);
                Rigidbody2D rbRef = hits[i].transform.gameObject.GetComponent<Rigidbody2D>();
                if (rbRef.mass > limitGrabByPlayer  )
                {
                    rb.AddForce(-propulsionDir * grabPower*100 * Time.fixedDeltaTime);
                    spriteRenderer.flipX = true;
                }








                else
                {
                    Anim.SetBool("Bumping", true);
                    rbRef.velocity = Vector2.zero;
                    rbRef.velocity = propulsionDir * grabPower*20 * Time.fixedDeltaTime;
                    rbRef.velocity = new Vector2(Mathf.Clamp(rbRef.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rbRef.velocity.y, -maxSpeed, maxSpeed)); // Limite de vitesse
                    
                }
            }
            canRepuls = false; // Désactive le grab pour le cooldown
            StartCoroutine(GrabCooldown(2f)); // Démarre le cooldown de 2 secondes

        }
        IEnumerator GrabCooldown(float cooldownDuration)
        {
            yield return new WaitForSeconds(cooldownDuration);
            canRepuls = true; // Réactive le grab après le cooldown
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

