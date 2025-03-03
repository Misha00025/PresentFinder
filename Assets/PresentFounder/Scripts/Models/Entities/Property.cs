using System;
using UnityEngine;

namespace Wof.PF.Models
{
    public class Property
    {
        private int _value;
        private int _maxValue;
        
        public Property(int maxValue)
        {
            _maxValue = maxValue;
            _value = _maxValue;
        }
        
        public event Action<int> Changed;
        
        public int Value 
        {
            get => _value;
            set => SetValue(value);
        }
        
        public int MaxValue => _maxValue;
        
        private void SetValue(int newHealth)
        {
            _value = newHealth > 0 ? newHealth : 0;
            _value = _value < _maxValue ? _value : _maxValue;
            Changed?.Invoke(_value); 
        }
    }
}
