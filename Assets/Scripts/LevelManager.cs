using UI;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject levelCompletedUI;  // Drag your LevelCompletedUI prefab here in the inspector
    private SceneChanger sceneChanger;   // Reference to our SceneChanger script

    private void Start()
    {
        levelCompletedUI = this.gameObject;
        
        // Ensure the UI is not shown at start
        //levelCompletedUI.SetActive(false);

        // Get the SceneChanger reference
        sceneChanger = FindObjectOfType<SceneChanger>();
    }

    // Call this function when your level is completed (based on your game's criteria)
    public void OnLevelCompleted()
    {
        levelCompletedUI.SetActive(true);
    }

    // This will be hooked up to the Next Level button
    public void LoadNextLevel()
    {
        // You can also manage this in a more sophisticated manner with a list or other data structure
        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        string nextScene = "Level" + (int.Parse(currentSceneName.Substring(5)) + 1);

        sceneChanger.ChangeSceneWithLoading(nextScene);
    }
}