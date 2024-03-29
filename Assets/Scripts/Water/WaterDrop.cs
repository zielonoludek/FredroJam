using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class WaterDrop : MonoBehaviour
{
    [SerializeField ] private List<GameObject> spriteList = new List<GameObject>();
    private WaterSpawn spawner;
    private List<GameObject> spawnPoints = new List<GameObject>();
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        spawner = FindObjectOfType<WaterSpawn>();
        GetChildren();
    }
    private void Start()
    {
        var num = Random.Range(1, spawner.spawnPoints.Count);

        transform.position = new Vector3(spawner.spawnPoints[num].transform.position.x, 7.8f, 0);
        
        for (int i = 2; i < spriteList.Count; i++) spriteList[i].gameObject.SetActive(false);
        Invoke("EnableGravity", 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteList[2].SetActive(false);
        spriteList[3].SetActive(false);
        ToggleVisibility3();
        Invoke("ToggleVisibility4", 0.1f);
        Invoke("DestroyObject", 3);
    }
    private void GetChildren() 
    {
        foreach (Transform child in this.GetComponentsInChildren<Transform>())
        {
            spriteList.Add(child.gameObject);
        }
        foreach (Transform child in spawner.GetComponentsInChildren<Transform>())
        {
            spawnPoints.Add(child.gameObject);
        }
    }
    private void DestroyObject() => Destroy(gameObject);
    
    // i know its bad x_x
    private void ToggleVisibility3() => spriteList[3].SetActive(!spriteList[3].activeSelf);
    private void ToggleVisibility4()
    {
        ToggleVisibility3();
        spriteList[4].SetActive(!spriteList[4].activeSelf);
    }
    private void EnableGravity()
    {
        spriteList[2].SetActive(true);
        spriteList[1].SetActive(false);
        rb.gravityScale = 1;
    }
}
