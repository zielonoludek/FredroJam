using System.Collections.Generic;
using UnityEngine;

public class WaterSpawn : MonoBehaviour
{
    [SerializeField] private GameObject waterDrop;
    [HideInInspector] public List<GameObject> spawnPoints = new List<GameObject>();

    private void Start()
    {
        foreach (Transform child in this.GetComponentsInChildren<Transform>()) spawnPoints.Add(child.gameObject);
        Instantiate(waterDrop);
        Invoke("SpawnWater", 1);
    }
    private void SpawnWater()
    { 
        Instantiate(waterDrop);
        Invoke("SpawnWater", 1);
    }
}