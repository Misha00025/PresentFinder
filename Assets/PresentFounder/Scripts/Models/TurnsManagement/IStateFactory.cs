using UnityEngine;

namespace Wof.PF.Models
{
    public interface IStateFactory
    {
        State CreateState(Turn turn);
    }
}
