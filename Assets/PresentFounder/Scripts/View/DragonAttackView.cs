using UnityEngine;
using UnityEngine.Events;

public class DragonAttackView : MonoBehaviour
{
    [SerializeField] private DragonController _dragonController;
    [SerializeField] private UnityEvent Missed;    
    [SerializeField] private UnityEvent Activated;
    [SerializeField] private UnityEvent<string> Prepared;
    

    public void ShowPrepare()
    {
        string message = _dragonController.PreparedAttack != null ? _dragonController.PreparedAttack.Name : "Ничего";
        Debug.Log($"Готовится атака: {message}");
        Prepared.Invoke(message);
    }
    
    public void ShowAttach(bool missing)
    {
        if (missing)
            Missed.Invoke();
        else    
            Activated.Invoke();
    }
}
