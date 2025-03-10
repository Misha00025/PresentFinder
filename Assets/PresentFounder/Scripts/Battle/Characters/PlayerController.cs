using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wof.PF.Models;

public class PlayerController : MyCharacterController
{
    [field: SerializeField] public List<Button> Buttons { get; private set; }
    [field: SerializeField] public List<PlayerActionType> Actions { get; private set; }
    [field: SerializeField] public PlayerView PlayerView { get; private set; }

    protected override void OnInstantiated()
    {
        if (Buttons.Count == 4)
        {
            Buttons[0].onClick.AddListener(()=>Activate(Actions[0]));
            Buttons[1].onClick.AddListener(()=>Activate(Actions[1]));
            Buttons[2].onClick.AddListener(()=>Activate(Actions[2]));
            Buttons[3].onClick.AddListener(()=>Activate(Actions[3]));
        }
    }

    public override void OnDisable()
    {
        SetButtons(false);
    }

    public override void OnEnable()
    {
        SetButtons(true);
    }
    
    private void SetButtons(bool interactable)
    {
        foreach (var button in Buttons)
        {
            button.interactable = interactable;
        }
    }
    
    protected void Activate(PlayerActionType actionType)
    {
        Debug.Log($"Action: {actionType}");
        SetButtons(false);
        PlayerView.ShowAction(
            actionType, 
            onEffect:() => {
                ActionRecorder.RegisterPlayerAction(actionType);
                Debug.Log($"Player action registered: {actionType}");
            }, 
            onEnd:EndTurn
        );   
    }
}
