using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MyCharacterController
{
    [field: SerializeField] public List<Button> Buttons { get; private set; }

    public override void OnDisable()
    {
        foreach (var button in Buttons)
        {
            button.interactable = false;
        }
    }

    public override void OnEnable()
    {
        foreach (var button in Buttons)
        {
            button.interactable = true;
        }
    }
    
    public void Bite()
    {
        
    }
    
    public void Scratch()
    {
        
    }
    
    public void Hiss()
    {
        
    }
    
    public void Purr()
    {
        
    }
}
