using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Wof.PF.Models;

public class PropertyView : MonoBehaviour
{
    public TextMeshProUGUI CurrentText;
    public TextMeshProUGUI MaxText;
    public SlicedFilledImage ScaleFiller;
    public UnityEvent PropertyChanged;
    private Property _model;
    private int MaxValue => _model.MaxValue;
    private float FillScale => (float)_model.Value / MaxValue;

    public void OnEnable()
    {
        if (_model != null)
            _model.Changed += OnPropertyChanged;
    }
    
    public void OnDisable()
    {
        if (_model != null)
            _model.Changed -= OnPropertyChanged; 
    }

    public void Instantiate(Property property)
    {
        _model = property;
        MaxText.SetText(MaxValue.ToString());
        OnPropertyChanged(_model.Value);
        _model.Changed += OnPropertyChanged;
    }
    
    private void OnPropertyChanged(int value)
    {
        CurrentText.SetText(value.ToString());
        ScaleFiller.fillAmount = FillScale;
        PropertyChanged.Invoke();
    }
}
