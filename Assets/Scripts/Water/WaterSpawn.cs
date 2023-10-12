using System.Collections.Generic;
using UnityEngine;

public class WaterSpawn : MonoBehaviour
{
    [SerializeField] private GameObject waterDrop;
    [HideInInspector] public List<GameObject> spawnPoints = new List<GameObject>();
    private float sec;

    private void Awake()
    {
        Instantiate(waterDrop);
    }
    private void Start()
    {
        foreach (Transform child in this.GetComponentsInChildren<Transform>()) spawnPoints.Add(child.gameObject);
        //Instantiate(waterDrop);

        sec = Random.Range(5, 15);
        Invoke("SpawnWater", sec);
    }
    private void SpawnWater()
    {
        sec = Random.Range(5, 15);
        Instantiate(waterDrop);
        Invoke("SpawnWater", sec);
    }
}