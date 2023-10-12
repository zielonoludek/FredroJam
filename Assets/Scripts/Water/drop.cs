using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class drop : MonoBehaviour
{
    private List<GameObject> spriteList = new List<GameObject>();
    private spawn spawner;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb.gravityScale = 0;
        Debug.Log("ok");
        rb = GetComponent<Rigidbody2D>();
        spawner = FindObjectOfType<spawn>();
    }
    private void Start()
    {
        Debug.Log("ok");
        var num = Random.Range(1, spawner.spawnPoints.Count + 1);
        transform.position = new Vector3(spawner.spawnPoints[1].transform.position.x, 8, 0);
        Debug.Log("ok");
        var sec = Random.Range(3, 5);
        GetChildren();
        for (int i = 2; i < spriteList.Count; i++)
        {
            if (spriteList[i].tag == "WaterDrop") spriteList[i].gameObject.SetActive(false);
        }

        Invoke("EnableGravity", sec);
    }
    private void OnEnable()
    {
        spriteList[2].SetActive(true);
        rb.gravityScale = 1;
    }
    private void OnCollisionEnter(Collision collision)
    { 
        ToggleVisibility3();
        Invoke("ToggleVivibility4", 0.2f);
        Invoke("DestroyObject", 3);
    }
    private void GetChildren() 
    {
        Debug.Log("kk");
        foreach (Transform child in this.GetComponentsInChildren<Transform>())
        {
            spriteList.Add(child.gameObject);
        }
    }
    private void DestroyObject() => Destroy(gameObject);
    
    // i know its bad x_x
    private void ToggleVisibility3() => spriteList[3].SetActive(!spriteList[3].activeSelf);
    private void ToggleVisibility4() => spriteList[4].SetActive(!spriteList[4].activeSelf);
}
