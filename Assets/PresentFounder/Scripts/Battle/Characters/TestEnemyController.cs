using System.Collections;
using UnityEngine;
using Wof.PF.Models;

public class TestEnemyController : EnemyController
{
    protected override IEnumerator Turn()
    {
        Debug.Log("Enemy Turn Started!");
        yield return new WaitForSeconds(1);
        if (LastPlayerAction != PlayerActionType.Hiss)
            ActionRecorder.RegisterEnemyAttack();
        EndTurn();
    }
}
