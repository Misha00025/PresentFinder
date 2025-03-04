using UnityEngine;
using Wof.PF.Models;

public abstract class MyCharacterController : MonoBehaviour
{
    private Character _model = null;
    private TurnManager _turnManager = null;
    private ActionRecorder _actionRecorder = null;
    private Turn _myTurn;
    
    public Character Model => _model;
    public ActionRecorder ActionRecorder => _actionRecorder;

    public void Instantiate(Character model, TurnManager turnManager, ActionRecorder actionRecorder)
    {
        if (_model == null)
            _model = model;
        if (_turnManager == null)
            _turnManager = turnManager;
        if (_actionRecorder == null)
            _actionRecorder = actionRecorder;
        _myTurn = new Turn(_model);
        _turnManager.Add(_myTurn);
        OnInstantiated();
    }

    protected virtual void OnInstantiated() {}

    public virtual void Enable()
    {
        gameObject.SetActive(true);
    }

    public virtual void Disable()
    {
        gameObject.SetActive(false);
    }

    protected bool IsMyTurn() => _turnManager.CurrentTurn == _myTurn;

    protected virtual void EndTurn()
    {
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
