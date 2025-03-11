using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Wof.PF.Models;

[Serializable]
public class DragonAttack {
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public DragonAttackView View { get; private set; }
    [SerializeField] private List<PlayerActionType> _weaknesses;
    
    public bool IsWeakness(PlayerActionType actionType)
    {
        return _weaknesses.Any(e => e == actionType);
    }     
}

public class DragonController : EnemyController
{
    [SerializeField] private float _timeout = 0.5f;
    [SerializeField] private List<DragonAttack> _dragonAttacks;
    [SerializeField] private DragonAttack _defaultAttack;
    
    private DragonAttack _preparedAttack = null;
    private DragonAttack _lastAttack = null;
    
    public DragonAttack PreparedAttack => _preparedAttack;
    
    private DragonAttack Attack 
    {
        get
        {
            if (_preparedAttack != null)
                return _preparedAttack;
            return _defaultAttack;
        }
    }
    
    protected override IEnumerator Turn()
    {
        var isPainful = IsPainful();
        yield return new WaitForSeconds(_timeout);
        if (_preparedAttack != null || CanAttack() || _lastAttack?.Name == "Удар хвостом")
            Attack.View.ShowAttach(!CanAttack());
        if (CanAttack())
            ActionRecorder.RegisterEnemyAttack();
        _lastAttack = _preparedAttack;
        _preparedAttack = null;
        if (IsProvoked() || isPainful)
        {
            yield return new WaitForSeconds(_timeout);
            PrepareAttack();
        }
        yield return new WaitForSeconds(_timeout);
        EndTurn();
    }
    
    private bool CanAttack()
    {
        if (_lastAttack != null)
        {
            var playerIsDodging = LastPlayerAction == PlayerActionType.Dodge;
            if (_lastAttack.Name == "Удар хвостом" && !playerIsDodging)
                return true;
            var ok = !playerIsDodging && !IsPainful();
            return ok;
        }
        else
        {
            return _defaultAttack.IsWeakness(LastPlayerAction);
        }
        
    }
    
    private bool IsPainful() => _lastAttack != null && _lastAttack.IsWeakness(LastPlayerAction);
    
    private bool IsProvoked()
    {
        var playerIsProvoking = LastPlayerAction == PlayerActionType.Hiss;
        return playerIsProvoking;
    }
    
    private void PrepareAttack()
    {
        var attackId = UnityEngine.Random.Range(0, _dragonAttacks.Count);
        _preparedAttack = _dragonAttacks[attackId];
        _preparedAttack.View.ShowPrepare();
    }
}
