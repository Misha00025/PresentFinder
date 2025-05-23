using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Wof.PF.Models;

[Serializable]
public class Sock
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public SockView View { get; private set; }
    [SerializeField] private List<PlayerActionType> _weaknesses;
    
    public bool CanAttack(PlayerActionType actionType)
    {
        return !_weaknesses.Any(e => e == actionType);
    }     
} 

public class SocksController : EnemyController
{
    [SerializeField] private List<Sock> _socks;
    [SerializeField] private float _afterAttackTime = 0.6f;
    [SerializeField] private float _afterPrepareTime = 0.2f;
    
    private List<Sock> _attackers = null;
    
    protected override IEnumerator Turn()
    {
        yield return ExecuteAttacks();
        yield return PrepareNextTurn();
        EndTurn();
    }
    
    private IEnumerator ExecuteAttacks()
    {
        if (_attackers != null)
            foreach (var attacker in _attackers)
            {   
                var canAttack = attacker.CanAttack(LastPlayerAction);
                attacker.View.ShowAttach(!canAttack);
                if (canAttack)
                {
                    yield return new WaitForSeconds(_afterAttackTime/2);
                    ActionRecorder.RegisterEnemyAttack();
                    yield return new WaitForSeconds(_afterAttackTime/2);                    
                }
            }
    }
    
    private IEnumerator PrepareNextTurn()
    {
        _attackers = _socks.ToList();
        if (_attackers.Count < 3)
            throw new Exception("Can't generate attacker's list");
        _attackers.RemoveAt(UnityEngine.Random.Range(0, _attackers.Count));
        _attackers.RemoveAt(UnityEngine.Random.Range(0, _attackers.Count));
        foreach (var attacker in _attackers)
        {
            attacker.View.ShowPrepare();
            yield return new WaitForSeconds(_afterPrepareTime);
        }
        yield return null;
    }
}
