using UnityEngine;

namespace UI

{
    public class LoadingSceneController : MonoBehaviour
    {
        // Automatically called when the scene starts
        private void Start()
        {
            //SceneChanger instance exists?
            if (SceneChanger.Instance != null)
            {
                SceneChanger.Instance.BeginLoading(); //Begin the asynchronous loading
            }
            else
            {
                Debug.LogError("SceneChanger instance not found. Please ensure it exists and is initialized before the LoadingScene is loaded.");
            }
        }
    }
}