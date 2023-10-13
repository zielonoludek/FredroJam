using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject mainMenuPanel;
    [SerializeField] public GameObject menuPanel;
    [SerializeField] private GameSettings gameSettings;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameSettings.isGamePaused= !gameSettings.isGamePaused;
            menuPanel.SetActive(gameSettings.isGamePaused);
        }
    }
}