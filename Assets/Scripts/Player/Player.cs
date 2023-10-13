using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private List<string> levels = new List<string>();
    private GameSettings settings;
    private PlayerData data;
    private string nextLevel;
    private int numberOfAnimals;

    private void Awake()
    {
        settings = GameState.instance.gameSettings;
        data = GameState.instance.playerData;
        levels = settings.Levels;
        numberOfAnimals = data.Animals.Count;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.tag);
        if (collider.gameObject.CompareTag("Teleporter"))
        {
            settings.numberOfLevel++;
            nextLevel = levels[settings.numberOfLevel];
            SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
        }
    }
}
