using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PhotoSlideshow : MonoBehaviour
{
    [Header("Fotos")]
    public Sprite[] photos;

    [Header("UI")]
    public Image photoImage;
    public CanvasGroup fadePanel;
    public Button nextButton;

    [Header("Tiempos")]
    public float fadeDuration = 1f;

    private int currentPhoto = 0;
    private bool isTransitioning = false;

    void Start()
    {
        // Mostrar la primera foto
        photoImage.sprite = photos[0];

        // Empezar completamente en negro
        fadePanel.alpha = 1f;

        // Activar el botón
        nextButton.onClick.AddListener(NextPhoto);

        // Hacer fade de entrada
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        yield return StartCoroutine(Fade(1f, 0f));
    }

    public void NextPhoto()
    {
        if (!isTransitioning)
        {
            StartCoroutine(ChangePhoto());
        }
    }

    IEnumerator ChangePhoto()
    {
        isTransitioning = true;

        // Fade a negro
        yield return StartCoroutine(Fade(0f, 1f));

        currentPhoto++;

        // ¿Hemos llegado al final?
        if (currentPhoto >= photos.Length)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("Se cierra el juego");
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif

            yield break;
        }

        // Cambiar la foto mientras la pantalla está negra
        photoImage.sprite = photos[currentPhoto];

        // Fade desde negro
        yield return StartCoroutine(Fade(1f, 0f));

        isTransitioning = false;
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;

            float alpha = Mathf.Lerp(
                startAlpha,
                endAlpha,
                time / fadeDuration
            );

            fadePanel.alpha = alpha;

            yield return null;
        }

        fadePanel.alpha = endAlpha;
    }
}