using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform target;  // Référence au transform du joueur
    bool start =true;
    // Variables pour définir la zone de suivi de la caméra
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private int i =0;
    public float speed;
    public int startingPoint;
    public Transform[] points;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        
    }

    //private void test()
    //{
    //    for (int i = 0; i < points.Length; i++)
    //    {
    //        Debug.Log(i);
    //        //if (transform.position == points[i-1].position + offset)
    //        //{
    //            //Debug.Log(points.Length);
    //            if (Vector2.Distance(transform.position, points[i].position + offset) < 1000f)
    //            {
    //                Debug.Log("check distance");
                    
    //                if (i == points.Length)
    //                {
    //                //changement de scene
    //                Debug.Log("changement de scene");
    //                }
    //            }

    //            if (i < points.Length)
    //            {
    //            Debug.Log("points.lenght");
    //                transform.position = Vector2.MoveTowards(transform.position, points[i].position + offset, speed * Time.deltaTime);
    //                transform.position = new Vector3(transform.position.x, transform.position.y, -10);
                
    //            }
    //        //}
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        //if(GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().enabled == false)
        //{
        //    if (start == true)
        //    {
        //        target = points[startingPoint];
        //        transform.position = points[startingPoint].position + offset;
        //        test();
        //        start = false;

        //    }

        //}
        
        

    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
