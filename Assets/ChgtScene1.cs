using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ChgtScene1 : MonoBehaviour
{
    public string sceneName; // Le nom de la scène à charger
    public float fadeDuration = 1f; // La durée du fondu en secondes
    public Image fadeImage; // L'image utilisée pour le fondu (assure-toi qu'elle remplit l'écran)

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ChangeSceneWithFade());
        }
    }

    private IEnumerator ChangeSceneWithFade()
    {
        // Affichage du fondu en fondu
        fadeImage.color = Color.clear;
        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = Color.black;

        // Chargement de la nouvelle scène
        SceneManager.LoadScene(sceneName);

        // Fondu en fondu de la nouvelle scène
        timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = Color.clear;
    }
}
