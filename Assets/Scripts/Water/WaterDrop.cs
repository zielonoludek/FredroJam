using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class WaterDrop : MonoBehaviour
{/*
    private Camera camera;
    private Vector3 target;
    private Rigidbody2D rb;
    private BulletSpawner gun;
    private float speed = 1000;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = FindObjectOfType<Camera>();
        gun = FindObjectOfType<BulletSpawner>();
    }
    public void Start()
    {
        transform.position = gun.transform.position;
        target = camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 force = (target - transform.position).normalized;
        rb.AddForce(force * speed);
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("RenderArea")) Destroy(gameObject);
        if (collider.gameObject.CompareTag("Movable")) Destroy(gameObject);
    }
    */
    private List<GameObject> spriteList = new List<GameObject>();
    private WaterSpawn spawner;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        spawner = FindObjectOfType<WaterSpawn>();
    }
    private void Start()
    {
        var num = Random.Range(1, spawner.spawnPoints.Count);
        transform.position = new Vector3(spawner.spawnPoints[num].transform.position.x, 7.75f, 0);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteList[2].SetActive(false);
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
        spriteList[1].SetActive(false); 
        spriteList[2].SetActive(true);
        rb.gravityScale = 1;
    }
}
