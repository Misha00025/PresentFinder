using UnityEngine;
using Wof.PF.Models;

public abstract class EnemyController : MyCharacterController
{
    protected PlayerActionType LastPlayerAction { get; private set; }

    protected override void OnInstantiated()
    {
        base.OnInstantiated();
        ActionRecorder.PlayerActionRecorded += OnPlayerActionRecorded;
    }
    
    private void OnPlayerActionRecorded(PlayerActionType actionType)
    {
        LastPlayerAction = actionType;
    }
    
    
    public void OnDestroy()
    {
        ActionRecorder.PlayerActionRecorded -= OnPlayerActionRecorded;
    }
}
