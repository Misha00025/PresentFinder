using System;
using UnityEngine;

namespace Wof.PF.Models
{
    public class State
    {
        public event Action Started;
        public event Action Ended;
        
        public virtual void Enter()
        {
            Started.Invoke();
        }
        
        public virtual void Exit()
        {
            Ended.Invoke();
        }
    }
}
