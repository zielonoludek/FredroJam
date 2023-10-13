using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private List<string> levels = new List<string>();
    [SerializeField] private GameSettings settings;
    private string nextLevel;

    private void Awake()
    {
        levels = settings.Levels;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Teleporter"))
        {
            settings.numberOfLevel++;
            nextLevel = levels[settings.numberOfLevel];
            SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WaterDrop"))
        {
            SceneManager.LoadScene("L2", LoadSceneMode.Single);
        }
    }
}
