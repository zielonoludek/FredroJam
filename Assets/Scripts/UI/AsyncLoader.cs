using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class AsyncLoader : MonoBehaviour
    {
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private Slider progressBar;

        private void Start()
        {
            loadingScreen.SetActive(false);
        }

        public void LoadScene(string sceneName)
        {
            loadingScreen.SetActive(true); // Enable loading screen UI
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        IEnumerator LoadSceneAsync(string sceneName)
        {
            yield return new WaitForSeconds(1.5f);  // Delay before loading

            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = false; // Prevent the scene from activating as soon as it's loaded
    
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                progressBar.value = progress;
        
                // Check if the scene is loaded but not yet activated
                if (operation.progress >= 0.9f)
                { 
                    yield return new WaitForSeconds(1.5f);  // Delay after loading
                    operation.allowSceneActivation = true; // Now allow the scene to activate
                }
        
                yield return null;
            }
        }
    }
}

