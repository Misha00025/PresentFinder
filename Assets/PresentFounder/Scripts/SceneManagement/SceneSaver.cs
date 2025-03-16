using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSaver : MonoBehaviour
{
    public void Awake()
    {
        var scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt("LastScene", scene.buildIndex);
        PlayerPrefs.Save();
    }   
}