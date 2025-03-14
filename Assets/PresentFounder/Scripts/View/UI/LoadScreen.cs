using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LoadScreen : MonoBehaviour
{
    public UnityEvent ShowInitiated;
    public UnityEvent HideInitiated;
    public float Delay = 1.0f;
    private bool _animationEnded = false;
    
    
    public void OnAnimationEnd()
    {
        _animationEnded = true;
    }

    public void Show(Action callback)
    {
        _animationEnded = false;
        ShowInitiated.Invoke();
        StartCoroutine(ShowAsync(callback));        
    }
    
    public void Hide()
    {
        _animationEnded = false;
        StartCoroutine(HideAsync());
    }
    
    private IEnumerator ShowAsync(Action callback)
    {
        while (!_animationEnded)
            yield return null;
        callback();
    }
    
    private IEnumerator HideAsync()
    {
        yield return new WaitForSeconds(Delay);
        HideInitiated.Invoke();
    }
}
