using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ChangeScene : MonoBehaviour
    {
        public void LoadSceneWithLoadingScreen(string sceneName)
        {
            PlayerPrefs.SetString("sceneToLoad", sceneName);
            SceneManager.LoadScene("LoadingScene");
        }
    }
}