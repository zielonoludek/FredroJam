using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static GameState instance;
    public GameSettings gameSettings;
    public PlayerData playerData;
    private ChangeScene changeScene;

    private void Awake() => Initialize();
    public void Initialize()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            LoadSettings();
            LoadMainMenu();
            return;
        }
        Destroy(gameObject);
    }
    private void LoadSettings()
    {
        Physics2D.IgnoreLayerCollision(0, 2);
        Physics2D.IgnoreLayerCollision(6, 3);
        Physics2D.IgnoreLayerCollision(0, 3);

        gameSettings = Resources.Load<GameSettings>("GameSettings");
        playerData = Resources.Load<PlayerData>("PlayerData");
        
        gameSettings.isGamePaused = false;
        gameSettings.isLevelRunning = false;
        gameSettings.isLibOpened = false;
        gameSettings.numberOfLevel = 0;

        playerData.animalNumber = 0;
    }
    private void LoadMainMenu() => SceneManager.LoadScene("Start", LoadSceneMode.Single);
}
