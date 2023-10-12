using UnityEngine;

public class Bird : Animal
{
    private Vector3 target;
    [SerializeField] private int targetNum;
    [SerializeField] private GameObject targetList;

    private void Start()
    {
        Debug.Log("start");
        renderArea = GameObject.FindGameObjectWithTag("RenderArea");
        targetList = GameObject.FindGameObjectWithTag("BirdTargets");
        GetChildren(targetList);
        RandomiseTarget();
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target) RandomiseTarget();
    }
    private void RandomiseTarget()
    {
        targetNum = Random.Range(1, childNum+1);
        target = new Vector3(childList[targetNum].transform.position.x, childList[targetNum].transform.position.y, 0);
    }
}