using DG.Tweening;
using UnityEngine;

public class PunchShakeEffect : MonoBehaviour
{
    // Направление, в котором будет происходить тряска
    public Vector2 shakeDirection = Vector2.right;

    // Продолжительность тряски
    public float shakeDuration = 0.25f;

    // Амплитуда тряски (величина смещения)
    public float shakeStrength = 0.5f;

    private Transform _transform;

    void Start()
    {
        _transform = transform;
    }

    // Метод, который будет вызван при получении урона
    public void Shake()
    {
        // Запускаем тряску объекта
        _transform.DOPunchPosition(shakeDirection * shakeStrength, shakeDuration);
    }
}
