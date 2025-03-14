using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static AsyncOperation _loadingSceneOperation = null;
    private static LoadScreen _loadScreen = null;

    public LoadScreen LoadScreen;
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
        if (_loadScreen == null && LoadScreen != null)
        {
            _loadScreen = LoadScreen;
            DontDestroyOnLoad(_loadScreen.gameObject);
        }
        else
            Destroy(LoadScreen);
    }
    
    void Update()
    {
        if (_loadingSceneOperation != null && _loadingSceneOperation.isDone && _loadScreen != null)
        {
            _loadingSceneOperation = null;
            _loadScreen.Hide();
        }
    }
    
    public void LoadLastScene()
    {
        ChangeScene(SceneManager.GetSceneByName(_lastScene).buildIndex);
    }
    
    public void LoadNextScene()
    {
        int nextId = CurrentId + 1;
        ChangeScene(nextId);
    }
    
    public void Restart()
    {
        ChangeScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ChangeScene(int id)
    {
        if (_loadScreen != null)
            _loadScreen.Show(() => {_loadingSceneOperation = SceneManager.LoadSceneAsync(id);});
        else
            _loadingSceneOperation = SceneManager.LoadSceneAsync(id);
    }
}
