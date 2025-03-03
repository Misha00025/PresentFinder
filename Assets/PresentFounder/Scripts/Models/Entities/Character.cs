using UnityEngine;

namespace Wof.PF.Models
{
    public class Character
    {
        private Property _health;
        
        public Character(Property health)
        {
            _health = health;
        }
        
        public Property Health => _health;
    }
}
