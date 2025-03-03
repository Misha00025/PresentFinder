using UnityEngine;
using Wof.PF.Models;

public class BattleCompositeRoot : MonoBehaviour
{
    private TurnManager _turnManager;

    private Character _player;
    private Character _enemy;
    
    public StateFactory StateFactory;    
    
    [Header("Player")]
    public CharacterTemplate PlayerTemplate;
    public CharacterStatsViewModel _playerView;
    
    [Header("Enemy")]
    public CharacterTemplate EnemyTemplate;
    public CharacterStatsViewModel _enemyView;
    

    void Start()
    {       
        _player = new Character(new Property(PlayerTemplate.MaxHealth));
        _enemy = new Character(new Property(EnemyTemplate.MaxHealth));
        
        StateFactory.Instantiate(_player);
        _turnManager = new TurnManager(new StateMachine(), StateFactory);
        StateFactory.PlayerController.Instantiate(_player, _turnManager);
        StateFactory.EnemyController.Instantiate(_enemy, _turnManager);
        
        _playerView.Instantiate(PlayerTemplate.Name, PlayerTemplate.Icon, _player);
        _enemyView.Instantiate(EnemyTemplate.Name, EnemyTemplate.Icon, _enemy);
    }
    
    public void TakeDamage(int damage)
    {
        _player.Health.Value -= damage;
    }
    
    public void TakeHeal(int heal)
    {
        _player.Health.Value += heal;
    }
}
