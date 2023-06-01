using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrasAimant : MonoBehaviour
{
    [SerializeField] private Transform playerSprite; // Référence au sprite du joueur
    [SerializeField] private Transform crosshair; // Référence au GameObject "crosshair"
    private Vector3 pivotPoint; // Point de pivot de rotation
    private Vector3 initialScale;

    private void Start()
    {
        // Définir le point de pivot comme position relative de l'objet par rapport au sprite du joueur
        pivotPoint = transform.localPosition;
        initialScale = transform.localScale;
    }

    private void Update()
    {
        // Calculer la direction du regard du joueur en utilisant la position du "crosshair"
        Vector3 lookDirection = crosshair.position - playerSprite.position;
        lookDirection.z = 0f; // Garder la direction en 2D en fixant la composante Z à zéro
        lookDirection.Normalize();

        // Calculer l'angle de rotation en utilisant la direction du regard
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        // Effectuer la rotation de l'objet autour du point de pivot
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Placer l'objet à l'emplacement du point de pivot sur le sprite du joueur
        transform.position = playerSprite.TransformPoint(pivotPoint);

        /*if (playerSprite.transform.localScale.x < 0)
        {
            // Inverser la direction du bras aimant lorsque le joueur fait un flip
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
        else
        {
            // Utiliser l'échelle initiale du bras aimant si le joueur ne fait pas de flip
            transform.localScale = initialScale;
        }*/

    }
}
