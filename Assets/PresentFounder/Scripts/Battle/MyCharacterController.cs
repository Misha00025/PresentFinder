using UnityEngine;
using Wof.PF.Models;

public abstract class MyCharacterController : MonoBehaviour
{
    private Character _model = null;
    private TurnManager _turnManager = null;
    private Turn _myTurn;
    
    public Character Model => _model;
    // protected TurnManager TurnManager => _turnManager;

    public void Instantiate(Character model, TurnManager turnManager)
    {
        if (_model == null)
            _model = model;
        if (_turnManager == null)
            _turnManager = turnManager;
        _myTurn = new Turn(_model);
        _turnManager.Add(_myTurn);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    protected bool IsMyTurn() => _turnManager.CurrentTurn == _myTurn;

    protected virtual void EndTurn()
    {
        Debug.Log($"Current turn: {_turnManager.CurrentTurn} : {_myTurn}");
        if (IsMyTurn())
        {
            Debug.Log("My turn ended!");
            _turnManager.NextTurn();
        }
        else
        {
            Debug.Log("There is not my turn!");
        }
    }

    public abstract void OnEnable();
    public abstract void OnDisable();
}
