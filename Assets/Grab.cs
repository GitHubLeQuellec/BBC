using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    Rigidbody2D rb;

    float horizontal_value;
    float vertical_value;


    private Vector2 aidepose;
    [SerializeField] GameObject aide;
    float range = 5;
    float grabPower = 10000;
    public GameObject aim;
    [SerializeField] float limitGrabByPlayer = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {

        aim.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aim.transform.position = new Vector3(aim.transform.position.x, aim.transform.position.y, 0);
        horizontal_value = Input.GetAxis("Horizontal");
        vertical_value = Input.GetAxis("Vertical");
        //flyingMode = Input.GetButtonDown();

        Vector3 direction = (aim.transform.position - transform.position);
        direction = Vector3.Normalize(direction);
        Debug.DrawRay(transform.position, direction * range, Color.magenta, 0, false);

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, range, LayerMask.GetMask("Grabbed"));

        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < hits.Length; i++)
            {

                Debug.Log(hits[i].collider.name);
                Rigidbody2D rbRef = hits[i].transform.gameObject.GetComponent<Rigidbody2D>();
                if (rbRef.mass > limitGrabByPlayer)
                {
                    rb.AddForce(direction * grabPower * Time.fixedDeltaTime);

                }
                else rbRef.AddForce(-direction * grabPower * Time.fixedDeltaTime);
            }
        }
    }
}
