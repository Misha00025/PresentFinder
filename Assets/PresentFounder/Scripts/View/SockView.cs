using DG.Tweening;
using TMPro;
using UnityEngine;

public class SockView : MonoBehaviour
{
    [SerializeField] private float _shakeStrength = 0.05f;
    [SerializeField] private float _shakeDuration = 0.2f;
    
    private Tween _shakeTween;
    // [SerializeField] private TextMeshProUGUI _logPanel;

    public void ShowPrepare()
    {
        StopAnimations();
        var targetTransform = transform;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(targetTransform.DOLocalMoveX(_shakeStrength, _shakeDuration / 2).SetRelative())
                .Append(targetTransform.DOLocalMoveX(-_shakeStrength, _shakeDuration / 2).SetRelative());
        _shakeTween = sequence.SetLoops(-1);
    }
    
    public void ShowAttach(bool missing)
    {
        StopAnimations();
        if (_shakeTween != null && _shakeTween.IsActive()){}
        
    }
    
    public void StopAnimations()
    {
        _shakeTween.Kill();
    }
}
