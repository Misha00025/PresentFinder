using DG.Tweening;
using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    public float shakeDuration = 0.25f;

    public float shakeStrength = 0.5f;

    public RectTransform _uiTransform;
    private Transform _transform;

    void Start()
    {
        _transform = transform;
    }

    public void Shake()
    {
        Debug.Log("Shake!");   
        if (_transform != null)
            _transform.DOShakePosition(shakeDuration, shakeStrength);
        if (_uiTransform != null)
        {
            Debug.Log("Shake ui element!");   
            _uiTransform.DOShakeAnchorPos(shakeDuration, shakeStrength*100);
        }
    }
}
