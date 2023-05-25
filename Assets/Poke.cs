using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poke : MonoBehaviour

{
    [SerializeField] GameObject player;
    bool Cam = false;
    public Transform[] points;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            player.GetComponent<Collider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<Player_Commande>().enabled = false;
            StartCoroutine(CamPoke());
        }

    }
    private IEnumerator CamPoke()
    {
        player.transform.position = points[0].position;
        yield return new WaitForSeconds(1);
        player.transform.position = points[1].position;
        yield return new WaitForSeconds(1);
        player.transform.position = points[2].position; 
        yield return new WaitForSeconds(1);
        player.transform.position = points[3].position;
        yield return new WaitForSeconds(1);
        player.transform.position = points[4].position;
        yield return new WaitForSeconds(1);
        player.transform.position = points[5].position;
        yield return new WaitForSeconds(1);
        player.transform.position = points[6].position;
        yield return new WaitForSeconds(1);
        player.transform.position = points[7].position;
        yield return new WaitForSeconds(1);
        player.transform.position = points[8].position;
        yield return new WaitForSeconds(1);
        player.transform.position = points[9].position;
        yield return new WaitForSeconds(1);
        player.transform.position = points[10].position;
        yield return new WaitForSeconds(1);
        player.transform.position = points[11].position;
        yield return new WaitForSeconds(1);
        player.transform.position = points[12].position;
    }
}
