using UnityEngine;
using UnityEngine.Events;
using Wof.PF.Models;

public class StateFactory : MonoBehaviour, IStateFactory
{
    private object _player;
    
    private MyCharacterController _playerController;
    private MyCharacterController _enemyController;
    
    public UnityEvent<object> TurnStarted = new();
    
    public void Instantiate(object player, MyCharacterController playerController, MyCharacterController enemyController)
    {
        _player = player;
        _playerController = playerController;
        _enemyController = enemyController;
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
        state.Started += _playerController.Enable;
        state.Ended += _playerController.Disable;
    }
    
    public void SetupEnemyState(ref State state)
    {
        state.Started += _enemyController.Enable;
        state.Ended += _enemyController.Disable;
    }
}
