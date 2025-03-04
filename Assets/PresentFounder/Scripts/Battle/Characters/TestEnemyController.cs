using System.Collections;
using UnityEngine;

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
        yield return new WaitForSeconds(5);
        EndTurn();
    }
}
