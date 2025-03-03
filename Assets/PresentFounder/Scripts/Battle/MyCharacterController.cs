using UnityEngine;
using Wof.PF.Models;

public abstract class MyCharacterController : MonoBehaviour
{
    private Character _model = null;
    private TurnManager _turnManager = null;
    
    public Character Model => _model;
    protected TurnManager TurnManager => _turnManager;

    public void Instantiate(Character model, TurnManager turnManager)
    {
        if (_model == null)
            _model = model;
        if (_turnManager == null)
            _turnManager = turnManager;
        _turnManager.Add(new Turn(_model));
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public abstract void OnEnable();
    public abstract void OnDisable();
}
