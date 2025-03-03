using UnityEngine;
using UnityEngine.UI;
using Wof.PF.Models;

public class BattleCompositeRoot : MonoBehaviour
{
    private Character _player;
    private Character _enemy;
    
    
    [Header("Player")]
    public string PlayerName;
    public Sprite PlayerSprite;
    public CharacterStatsViewModel _playerView;
    
    [Header("Enemy")]
    public string EnemyName;
    public Sprite EnemySprite;
    public CharacterStatsViewModel _enemyView;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = new Character(new Property(100));
        _enemy = new Character(new Property(20));
        
        _playerView.Instantiate(PlayerName, PlayerSprite, _player);
        _enemyView.Instantiate(EnemyName, EnemySprite, _enemy);
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
