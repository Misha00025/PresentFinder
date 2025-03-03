using UnityEngine;
using UnityEngine.UI;
using Wof.PF.Models;

public class BattleCompositeRoot : MonoBehaviour
{
    private Character _player;
    private Character _enemy;
    
    
    [Header("Player")]
    public CharacterTemplate PlayerTemplate;
    public CharacterStatsViewModel _playerView;
    
    [Header("Enemy")]
    public CharacterTemplate EnemyTemplate;
    public CharacterStatsViewModel _enemyView;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = new Character(new Property(PlayerTemplate.MaxHealth));
        _enemy = new Character(new Property(EnemyTemplate.MaxHealth));
        
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
