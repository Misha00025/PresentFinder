using UnityEngine;

public class DragonAttackView : MonoBehaviour
{
    [SerializeField] private DragonController _dragonController;

    public void ShowPrepare()
    {
        string message = _dragonController.PreparedAttack != null ? _dragonController.PreparedAttack.Name : "Ничего";
        Debug.Log($"Готовится атака: {message}");
    }
    
    public void ShowAttach(bool missing)
    {
        
    }
}
