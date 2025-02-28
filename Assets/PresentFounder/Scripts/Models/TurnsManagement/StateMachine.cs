using UnityEngine;

namespace Wof.PF.Models
{
    public class StateMachine
    {
        private State currentState;

        public void ChangeState(State newState) {
            currentState?.Exit();
            
            currentState = newState;
            currentState.Enter();
        }
    }
}
