using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerUIHider : MonoBehaviour
{
    // Левая и правая панели
    public RectTransform leftPanel;
    public RectTransform rightPanel;
    
    // Скорость анимации
    public float animationDuration = 0.5f;

    // Начальные позиции панелей
    private Vector2 leftPanelStartPosition;
    private Vector2 rightPanelStartPosition;

    void Awake()
    {
        // Сохраняем начальные позиции панелей
        leftPanelStartPosition = leftPanel.anchoredPosition;
        rightPanelStartPosition = rightPanel.anchoredPosition;
    }

    public void ShowUI()
    {
        if (leftPanel != null)
        {
            leftPanel.anchoredPosition = new Vector2(-Screen.width, leftPanel.anchoredPosition.y);
            leftPanel.DOAnchorPos(leftPanelStartPosition, animationDuration);
        }

        if (rightPanel != null)
        {
            rightPanel.anchoredPosition = new Vector2(Screen.width, rightPanel.anchoredPosition.y);
            rightPanel.DOAnchorPos(rightPanelStartPosition, animationDuration);
        }
    }

    public void HideUI()
    {
        if (leftPanel != null)
        {
            leftPanel.DOAnchorPos(new Vector2(-Screen.width, leftPanel.anchoredPosition.y), animationDuration);
        }

        if (rightPanel != null)
        {
            rightPanel.DOAnchorPos(new Vector2(Screen.width, rightPanel.anchoredPosition.y), animationDuration);
        }
    }

    void OnEnable()
    {
        ShowUI();        
    }

    void OnDisable()
    {
        HideUI();        
    }
}