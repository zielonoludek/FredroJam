using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings", order = 1)]

public class GameSettings : ScriptableObject
{
    [Header("Scenes")]
    public string MainMenu = "Start";
    public List<string> Levels = new List<string>();

    public int numberOfLevel;
    public bool isGamePaused;
    public bool isLevelRunning;
    public bool isLibOpened;
}