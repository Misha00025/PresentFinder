using UnityEngine;
using UnityEngine.Events;
using Wof.PF.Models;

public class StateFactory : MonoBehaviour, IStateFactory
{
    private object _player;
    
    [field: SerializeField] public MyCharacterController PlayerController { get; private set; }
    [field: SerializeField] public MyCharacterController EnemyController { get; private set; }
    
    public UnityEvent<object> TurnStarted = new();
    
    public void Instantiate(object player)
    {
        _player = player;  
    }
    
    public State CreateState(Turn turn)
    {
        var state = new State();
        if (turn.Entity == _player)
            SetupPlayerState(ref state);
        else
            SetupEnemyState(ref state);
        state.Started += () => { TurnStarted.Invoke(turn.Entity); };
        return state;
    }
    
    public void SetupPlayerState(ref State state)
    {
        state.Started += PlayerController.Enable;
        state.Ended += PlayerController.Disable;
    }
    
    public void SetupEnemyState(ref State state)
    {
        state.Started += EnemyController.Enable;
        state.Ended += EnemyController.Disable;
    }
}
