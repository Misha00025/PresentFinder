using UnityEngine;

namespace Wof.PF.Models
{
    public class Character
    {
        private int _damage;
        private Property _health;
        
        public Character(Property health, int damage)
        {
            _health = health;
            _damage = damage;
        }
        
        public int Damage => _damage;
        public Property Health => _health;
    }
}
