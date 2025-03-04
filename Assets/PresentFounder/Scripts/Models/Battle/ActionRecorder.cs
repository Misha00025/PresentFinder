using System;
using UnityEngine;

namespace Wof.PF.Models
{
    public class ActionRecorder
    {
        public event Action<PlayerActionType> PlayerActionRecorded;
        private Character _player;
        private Character _enemy;
    
        public ActionRecorder(Character player, Character enemy)
        {
            _player = player;
            _enemy = enemy;
        }
    
        public void RegisterPlayerAction(PlayerActionType actionType)
        {
            switch(actionType)
            {
                case PlayerActionType.Bite:
                case PlayerActionType.Scratch:
                    _enemy.Health.Value -= 1;
                    break;
                case PlayerActionType.Hiss:
                    break;
                case PlayerActionType.Retreat:
                    break;
                default:
                    break;
            }
            PlayerActionRecorded?.Invoke(actionType);
        }
        
        public void RegisterEnemyAttack(int damage)
        {
            _player.Health.Value -= damage;
        }
    } 
}
