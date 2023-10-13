using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button exitToMenuBtn;
    [SerializeField] private Button quitBtn;

    [SerializeField] private GameSettings gameSettings;

    private void Awake()
    {
        gameObject.SetActive(false);
        resumeBtn.onClick.AddListener(ResumeButton);
        exitToMenuBtn.onClick.AddListener(ExitToMainMenuButton);
        quitBtn.onClick.AddListener(QuitButton);
    }
    private void ResumeButton()
    {
        gameSettings.isGamePaused = false;
        gameObject.SetActive(false);
    }
    private void ExitToMainMenuButton()
    {
        //gameSettings.isLevelRunning = false;
        SceneManager.LoadScene(gameSettings.MainMenu, LoadSceneMode.Single);
    }
    private void QuitButton()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}