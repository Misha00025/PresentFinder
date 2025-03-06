using UnityEngine;
using UnityEngine.Events;

public class Starter : MonoBehaviour
{
    public UnityEvent SceneStarted;

    void Start()
    {
        SceneStarted.Invoke();
    }
}
