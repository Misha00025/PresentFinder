using UnityEngine;
using UnityEngine.Events;
using Wof.PF.Models;

public class BattleController : MonoBehaviour
{
    public UnityEvent BattleEnded;
    public UnityEvent Win;
    public UnityEvent Lose;
    
    private TurnManager _turnManager;
    private PlayerController _playerController;
    private EnemyController _enemyController;
    
    public void Instantiate(TurnManager turnManager, PlayerController playerController, EnemyController enemyController)
    {
        _turnManager = turnManager;
        _playerController = playerController;
        _enemyController = enemyController;
        BattleEnded.AddListener(() => 
        {
           _playerController.gameObject.SetActive(false); 
           _enemyController.gameObject.SetActive(false); 
        });
        _turnManager.TurnEnded += CheckEndGame;
    }
    
    public void OnEnable()
    {
        if (_turnManager != null)
            _turnManager.TurnEnded += CheckEndGame;
    }
    
    public void OnDisable()
    {
        if (_turnManager != null)
            _turnManager.TurnEnded -= CheckEndGame;
    }
    
    private void CheckEndGame()
    {
        var playerDefied = _playerController.Model.Health.Value == 0;
        var enemyDefied = _enemyController.Model.Health.Value == 0;
        if (playerDefied || enemyDefied)
        {
            BattleEnded.Invoke();
            if (enemyDefied)
                Win.Invoke();
            else 
                Lose.Invoke();
        }
    }

    public void StartBattle()
    {
        _turnManager.NextTurn();
    }
}
