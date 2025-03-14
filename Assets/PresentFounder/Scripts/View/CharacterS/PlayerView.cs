using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Wof.PF.Models;

public class PlayerView : MonoBehaviour
{    
    [Serializable]
    public struct PlayerActionsView 
    {
        public PlayerActionType ActionType;
        public UnityEvent Activated;
    }

    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerActionsView[] _actionsEvents;
    
    private Action _onEffect;
    private Action _onEnd;

    public void ShowAction(PlayerActionType actionType, Action onEffect = null,  Action onEnd = null)
    {
        var animationData = _actionsEvents.FirstOrDefault(x => x.ActionType == actionType);
        _onEffect = onEffect;
        _onEnd = onEnd;
        _animator.applyRootMotion = false;
        animationData.Activated?.Invoke();
    }
    
    public void TriggerEffect()
    {
        if (_onEffect != null)
            _onEffect();
        _onEffect = null;
    }
    
    public void OnAnimationEnd()
    {
        if (_onEnd != null)
            _onEnd();
        _onEnd = null;
    }
    
    public void OnIdleEnter()
    {
        _animator.applyRootMotion = true;
    }
}
