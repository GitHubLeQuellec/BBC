using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBoss : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera Cam2;
    public float zoomAmount = 5f;
    [SerializeField] GameObject boss;

    private float originalOrthographicSize;

    private void Start()
    {
        //originalOrthographicSize = mainCamera.orthographicSize;
        Cam2.enabled = false;
        boss.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //mainCamera.orthographicSize = originalOrthographicSize - zoomAmount;
            mainCamera.enabled = false;
            Cam2.enabled = true;
            other.gameObject.GetComponent<Grab>().cam = Cam2;
            other.gameObject.GetComponent<Grab1>().cam = Cam2;
            boss.SetActive(true);
        }
    }

   
}
