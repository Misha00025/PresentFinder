using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wof.PF.Models;

public class PlayerController : MyCharacterController
{
    [field: SerializeField] public List<Button> Buttons { get; private set; }

    public void Start()
    {
        if (Buttons.Count == 4)
        {
            Buttons[0].onClick.AddListener(Bite);
            Buttons[1].onClick.AddListener(Scratch);
            Buttons[2].onClick.AddListener(Hiss);
            Buttons[3].onClick.AddListener(Retreat);
        }
    }

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
        Debug.Log("Bite!");
        EndTurn();
    }
    
    public void Scratch()
    {
        Debug.Log("Scratch!");
        EndTurn();
    }
    
    public void Hiss()
    {
        Debug.Log("Hiss!");
        EndTurn();
    }
    
    public void Retreat()
    {
        Debug.Log("Retreat!");
        EndTurn();
    }
}
