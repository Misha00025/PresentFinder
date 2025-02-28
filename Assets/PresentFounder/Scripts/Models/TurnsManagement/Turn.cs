using UnityEngine;

namespace Wof.PF.Models
{
    public class Turn
    {
        private object _entity;
        
        public Turn(object entity)
        {
            _entity = entity;
        }
        
        public object Entity => _entity;
    }
}
