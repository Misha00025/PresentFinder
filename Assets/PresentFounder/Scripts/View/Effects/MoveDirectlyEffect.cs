using System.Collections;
using DG.Tweening;
using UnityEngine;


public class MoveDirectlyEffect : MonoBehaviour
{
    public Vector2 Direction = new Vector2(1, 0);
    public float Distance = 1f;
    public float Duration = 1f;
    private Transform _transform;
    private Vector3 _originalPosition;
    private Sequence sequence;

    public void Start()
    {
        _transform = transform;
        _originalPosition = _transform.position;
    }

    public void MoveAndReturn()
    {
        StartCoroutine(Do());
    }
    
    private IEnumerator Do()
    {
        yield return null;
        // Создаем последовательность движений
        sequence = DOTween.Sequence();

        // Перемещаем объект в указанном направлении
        sequence.Append(_transform.DOMove(_transform.position + (Vector3)Direction * Distance, Duration / 2f));

        // Возвращаем объект в исходную позицию
        sequence.Append(_transform.DOMove(_originalPosition, Duration / 2f));
        sequence.Play();
    }
}
