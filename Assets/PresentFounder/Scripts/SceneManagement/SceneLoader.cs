using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public UnityEvent LastSceneFounded;
    private string _lastScene = null;
    public int CurrentId => SceneManager.GetActiveScene().buildIndex;
    
    public void Awake()
    {
        if (PlayerPrefs.HasKey("LastScene"))
        {
            _lastScene = PlayerPrefs.GetString("LastScene");
            LastSceneFounded.Invoke();
        }
    }
    
    public void LoadLastScene()
    {
        SceneManager.LoadScene(_lastScene);
    }
    
    public void LoadNextScene()
    {
        int nextId = CurrentId + 1;
        SceneManager.LoadScene(nextId);
    }
}
