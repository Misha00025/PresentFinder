using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Wof.PF.Models
{
    public class TurnManager {
        private StateMachine _machine;
        private IStateFactory _stateFactory;
        private Queue<Turn> _playedTurns = new();
        private Queue<Turn> _turns = new();

        public event Action RoundEnded;
        public event Action TurnEnded;

        public TurnManager(StateMachine stateMachine, IStateFactory stateFactory) 
        {
            _machine = stateMachine;
            _stateFactory = stateFactory;
        }

        public IReadOnlyCollection<Turn> Turns {
            get
            {
                var turns = _playedTurns.ToList();
                turns.AddRange(_turns.ToList());
                return turns;
            }
        }
        
        public Turn CurrentTurn => _playedTurns.Last();

        public void Add(Turn turn)
        {
            _turns.Enqueue(turn);
        }

        public void Remove(Turn turn)
        {
            Queue<Turn> turns;
            if (_turns.Contains(turn))
                turns = _turns;
            else if (_playedTurns.Contains(turn))
                turns = _playedTurns;
            else
                throw new Exception("This turn is not founded");
            for (var i = 0; i < turns.Count; i++)
            {
                var tmpTurn = turns.Dequeue();
                if (tmpTurn != turn)
                    turns.Enqueue(tmpTurn);
            }        
        }       

        public void NextTurn() 
        {
            if (_turns.Count == 0)
            {
                var tmp = _playedTurns;
                _playedTurns = _turns;
                _turns = tmp;
                RoundEnded?.Invoke();                
            }
            var turn = _turns.Dequeue();
            var state = _stateFactory.CreateState(turn);
            state.Ended += () => { TurnEnded?.Invoke(); };
            _machine.ChangeState(state);
            _playedTurns.Enqueue(turn);
        }
    }
}
