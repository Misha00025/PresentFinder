using UnityEngine;
using Wof.PF.Models;

[RequireComponent(typeof(StateFactory))]
public class BattleCompositeRoot : MonoBehaviour
{
    private TurnManager _turnManager;

    private Character _player;
    private Character _enemy;
    
    private PlayerController _playerController;
    private EnemyController _enemyController;
    private StateFactory _stateFactory;    
    
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
    }

    void Start()
    {       
        FindReferences();
        SetupCharacters();
        SetupTurnManagement();
        SetupCharactersControllers();
        SetupView();
        StartBattle();
    }
    
    private void SetupCharacters()
    {
        _player = new Character(new Property(PlayerTemplate.MaxHealth));
        _enemy = new Character(new Property(EnemyTemplate.MaxHealth));        
    }
    
    private void SetupTurnManagement()
    {
        _stateFactory.Instantiate(_player);
        _turnManager = new TurnManager(new StateMachine(), _stateFactory);
        _stateFactory.PlayerController.Instantiate(_player, _turnManager);
        _stateFactory.EnemyController.Instantiate(_enemy, _turnManager);
    }
    
    private void SetupCharactersControllers()
    {
        // _playerController.Instantiate(_player, _turnManager);
        _playerController.Disable();
        // _enemyController.Instantiate(_enemy, _turnManager);
        _enemyController.Disable();
    }
    
    private void SetupView()
    {
        PlayerView.Instantiate(PlayerTemplate.Name, PlayerTemplate.Icon, _player);
        EnemyView.Instantiate(EnemyTemplate.Name, EnemyTemplate.Icon, _enemy);        
    }
    
    private void StartBattle()
    {
        _turnManager.NextTurn();
    }
}
