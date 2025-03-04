using System.Collections;
using UnityEngine;
using Wof.PF.Models;

public class TestEnemyController : EnemyController
{
    public override void OnDisable()
    {
        StopAllCoroutines();
    }

    public override void OnEnable()
    {
        StartCoroutine(MyTurn());
    }
    
    
    private IEnumerator MyTurn()
    {
        Debug.Log("Enemy Turn Started!");
        yield return new WaitForSeconds(1);
        if (LastPlayerAction != PlayerActionType.Hiss)
            ActionRecorder.RegisterEnemyAttack(5);
        EndTurn();
    }
}
