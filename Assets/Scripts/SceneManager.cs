using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Call this function and provide the name of the scene you want to load
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }
}

