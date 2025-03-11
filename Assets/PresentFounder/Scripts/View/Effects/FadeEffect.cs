using UnityEngine;
using DG.Tweening;

public class FadeEffect : MonoBehaviour
{
    // Компонент CanvasGroup для UI элементов
    private CanvasGroup canvasGroup;

    // Компонент SpriteRenderer для спрайтов
    private SpriteRenderer spriteRenderer;

    // Длительность анимации
    public float fadeDuration = 1f;

    void Awake()
    {
        // Проверяем наличие CanvasGroup или SpriteRenderer
        canvasGroup = GetComponent<CanvasGroup>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Медленно исчезает объект
    /// </summary>
    public void FadeOut()
    {
        if (canvasGroup != null)
        {
            canvasGroup.DOFade(0f, fadeDuration);
        }
        else if (spriteRenderer != null)
        {
            spriteRenderer.material.DOFade(0f, fadeDuration);
        }
    }

    /// <summary>
    /// Медленно появляется объект
    /// </summary>
    public void FadeIn()
    {
        if (canvasGroup != null)
        {
            canvasGroup.DOFade(1f, fadeDuration);
        }
        else if (spriteRenderer != null)
        {
            spriteRenderer.material.DOFade(1f, fadeDuration);
        }
    }
}