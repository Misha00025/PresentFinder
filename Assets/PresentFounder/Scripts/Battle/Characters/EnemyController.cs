using System.Collections;
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
        
    public override void OnDisable()
    {
        StopAllCoroutines();
    }

    public override void OnEnable()
    {
        if (Model.Health.Value > 0) 
            StartCoroutine(Turn());
    }
        
    public void OnDestroy()
    {
        ActionRecorder.PlayerActionRecorded -= OnPlayerActionRecorded;
    }
    
    protected abstract IEnumerator Turn();
}
