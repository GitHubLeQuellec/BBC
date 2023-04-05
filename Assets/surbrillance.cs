using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surbrillance : MonoBehaviour
{
    // Temps entre chaque changement de couleur
    public float blinkInterval = 0.1f;

    // Couleur initiale de l'objet
    private Color originalColor;

    void Start()
    {
        // R�cup�ration du Renderer de l'objet
        Renderer renderer = GetComponent<Renderer>();

        // Sauvegarde de la couleur originale
        originalColor = renderer.material.color;

        // Lancement de la coroutine de clignotement
        StartCoroutine(Blink(renderer));
    }

    // Coroutine de clignotement
    IEnumerator Blink(Renderer renderer)
    {
        while (true)
        {
            // Changement de la couleur de l'objet
            renderer.material.color = Color.blue;

            // Attente du temps d�fini pour le clignotement
            yield return new WaitForSeconds(blinkInterval);

            // Changement de la couleur de l'objet
            renderer.material.color = originalColor;

            // Attente du temps d�fini pour le clignotement
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}