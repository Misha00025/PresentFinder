using System;
using UnityEngine;
using UnityEngine.Events;
using Wof.PF.Models;

[RequireComponent(typeof(StateFactory))]
public class BattleCompositeRoot : MonoBehaviour
{
    private StateFactory _stateFactory; 
    private TurnManager _turnManager;
    private ActionRecorder _actionRecorder;

    private Character _player;
    private Character _enemy;
    
    private PlayerController _playerController;
    private EnemyController _enemyController;  
    private BattleController _battleController;
    
    public UnityEvent SceneLoaded;
    
    [Header("Player")]
    public CharacterTemplate PlayerTemplate;
    public CharacterStatsViewModel PlayerView;
    
    [Header("Enemy")]
    public CharacterTemplate EnemyTemplate;
    public CharacterStatsViewModel EnemyView;
    
    private void FindReferences()
    {
        _stateFactory = gameObject.GetComponent<StateFactory>();
        _playerController = gameObject.GetComponentInChildren<PlayerController>(includeInactive: true);
        _enemyController = gameObject.GetComponentInChildren<EnemyController>(includeInactive: true);
        _battleController = gameObject.GetComponentInChildren<BattleController>(includeInactive: true);
    }

    void Start()
    {       
        FindReferences();
        SetupCharacters();
        SetupGameplayComponents();
        SetupCharactersControllers();
        SetupView();
        SetupBattle();
        SceneLoaded.Invoke();
    }

    private void SetupCharacters()
    {
        _player = new Character(new Property(PlayerTemplate.MaxHealth), PlayerTemplate.Damage);
        _enemy = new Character(new Property(EnemyTemplate.MaxHealth), EnemyTemplate.Damage);        
    }
    
    private void SetupGameplayComponents()
    {
        _stateFactory.Instantiate(_player, _playerController, _enemyController);
        _turnManager = new TurnManager(new StateMachine(), _stateFactory);
        _actionRecorder = new ActionRecorder(_player, _enemy);
        
    }
    
    private void SetupCharactersControllers()
    {
        _playerController.Instantiate(_player, _turnManager, _actionRecorder);
        _playerController.Disable();
        _enemyController.Instantiate(_enemy, _turnManager, _actionRecorder);
        _enemyController.Disable();
    }
    
    private void SetupView()
    {
        PlayerView.Instantiate(PlayerTemplate.Name, PlayerTemplate.Icon, _player);
        EnemyView.Instantiate(EnemyTemplate.Name, EnemyTemplate.Icon, _enemy);        
    }

    private void SetupBattle()
    {
        _battleController.Instantiate(_turnManager, _playerController, _enemyController);
    }
    
}
