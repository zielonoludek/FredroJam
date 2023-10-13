using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Animal : MonoBehaviour
{
     private float hp;
     public float speed;

    [SerializeField] GameSettings settings;
    [HideInInspector] public GameObject renderArea;
     [HideInInspector] public float roomLength;
     [HideInInspector] public float roomHeight;

     [HideInInspector] public int childNum;
     [HideInInspector] public List<GameObject> childList = new List<GameObject>();
     [SerializeField] private Animator animator;

    private void Awake()
    { 
        SetHP(Random.Range(1, 3));
        renderArea = GameObject.FindGameObjectWithTag("RenderArea");
        roomLength = renderArea.transform.localScale.x;
        roomHeight = renderArea.transform.localScale.y;
        speed = Random.Range(3, 10);
        settings = GameState.instance.gameSettings;

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Bullet")) Hit();
    }
    private void SetHP(float number) => hp = number;
    private void Hit()
    {
        hp -= 1;
        if (hp < 1) Destroy(gameObject);
    }
    public void GetChildren(GameObject parent)
    {
        foreach (Transform child in parent.GetComponentsInChildren<Transform>())
        {
            childList.Add(child.gameObject);
        }
        childNum = parent.transform.childCount;
    }
    public void Move(Vector3 target)
    {
        if (settings.isLevelRunning && !settings.isGamePaused)
        {
            animator.SetFloat("Speed", speed);
            if (transform.position == target) Invoke("RandomiseTarget", 0.5f);
            else transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
    private void OnDestroy()
    {
        GameState.instance.playerData.animalNumber++;
    }
}
