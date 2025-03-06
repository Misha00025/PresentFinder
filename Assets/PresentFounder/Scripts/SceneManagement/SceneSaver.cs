using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSaver : MonoBehaviour
{
    public void Awake()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LastScene", sceneName);
        PlayerPrefs.Save();
    }   
}