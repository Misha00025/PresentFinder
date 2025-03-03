using TMPro;
using Unity.Android.Gradle;
using UnityEngine;
using UnityEngine.UI;
using Wof.PF.Models;

public class CharacterStatsViewModel : MonoBehaviour
{
    private Character _model;
    
    public Image Icon;
    public TextMeshProUGUI NameText;
    public PropertyView Health;
    
    public void Instantiate(string name, Sprite icon, Character model)
    {
        _model = model;
        NameText.SetText(name);
        Icon.sprite = icon;
        Health.Instantiate(_model.Health);
    }
}
