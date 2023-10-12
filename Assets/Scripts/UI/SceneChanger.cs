using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI

{
    public class SceneChanger : MonoBehaviour
    {
        public static SceneChanger Instance; // Singleton reference

        [HideInInspector]
        public string sceneToLoad;
        
        private Slider progressBar;

        private void Awake()
        {
            // Singleton pattern
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Initiates the scene change process (Call This)
        public void ChangeSceneWithLoading(string targetScene)
        {
            sceneToLoad = targetScene;
            SceneManager.LoadScene("LoadingScene");
        }

        // Triggered from the LoadingScene's Start()
        public void BeginLoading()
        {
            progressBar = FindObjectOfType<Slider>(); // Assume you have a Slider in your LoadingScene
            StartCoroutine(LoadAsyncScene());
        }

        // Subroutine
        private System.Collections.IEnumerator LoadAsyncScene()
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

            while (!asyncLoad.isDone)
            {
                // Update the progress bar's value
                progressBar.value = asyncLoad.progress;
                yield return null;
            }
        }
    }
}