using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private GameObject levelCompletedUI;  // Drag your LevelCompletedUI prefab here in the inspector
    
    private void Start()
    {
        levelCompletedUI = this.gameObject;
        
        // Ensure the UI is not shown at start
        //levelCompletedUI.SetActive(false);

        
    }

    // Call this function when your level is completed (based on your game's criteria)
    public void OnLevelCompleted()
    {
        levelCompletedUI.SetActive(true);
    }

    // This will be hooked up to the Next Level button
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}