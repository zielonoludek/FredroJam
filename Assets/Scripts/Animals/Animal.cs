using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Animal : MonoBehaviour
{
     private float hp;
     public float speed;
     
     [HideInInspector] public GameObject renderArea;
     [HideInInspector] public float roomLength;
     [HideInInspector] public float roomHeight;

     [HideInInspector] public int childNum;
     [HideInInspector] public List<GameObject> childList = new List<GameObject>();
     [SerializeField] private Animator animator;

    private void Awake()
    {
        Physics2D.IgnoreLayerCollision(6, 3);
        Physics2D.IgnoreLayerCollision(0, 3);
        SetHP(Random.Range(1, 3));
        renderArea = GameObject.FindGameObjectWithTag("RenderArea");
        roomLength = renderArea.transform.localScale.x;
        roomHeight = renderArea.transform.localScale.y;
        speed = Random.Range(1, 7);
    }
    private void OnDestroy() => Debug.Log("Animal defeated");
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
        Debug.Log("get children");
        foreach (Transform child in parent.GetComponentsInChildren<Transform>())
        {
            childList.Add(child.gameObject);
        }
        childNum = parent.transform.childCount;
    }
    public void Move(Vector3 target)
    {
        animator.SetFloat("Speed", speed);
        if (transform.position == target) Invoke("RandomiseTarget", 0.5f);
        else transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
