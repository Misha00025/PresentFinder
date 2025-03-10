using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;

public class ColorTint : MonoBehaviour
{
    public Color TintColor = new Color(1f, 0f, 0f, 0.75f);
    public float Duration = 0.5f;
    public List<SpriteRenderer> _images;
    
    void Start()
    {
        _images = GetComponentsInChildren<SpriteRenderer>(true).ToList();
        if (TryGetComponent<SpriteRenderer>(out var image))
            _images.Add(image);
    }
    
    public void ChangeColor()
    {
        foreach (var image in _images)
        {
            Color originalColor = image.color;
            Color targetColor = TintColor;
            image.DOColor(targetColor, Duration/2)
                .OnComplete(() => image.DOColor(originalColor, Duration/2));
        }
    }
}