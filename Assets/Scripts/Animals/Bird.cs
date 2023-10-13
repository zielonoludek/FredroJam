using UnityEngine;

public class Bird : Animal
{
    private Vector3 target;
    private int targetNum;
    private GameObject targetList;

    private void Start()
    {
        renderArea = GameObject.FindGameObjectWithTag("RenderArea");
        targetList = GameObject.FindGameObjectWithTag("BirdTargets");
        GetChildren(targetList);
        RandomiseTarget();
    }
    private void Update() => Move(target);
    private void RandomiseTarget()
    {
        targetNum = Random.Range(1, childNum+1);
        target = new Vector3(childList[targetNum].transform.position.x, childList[targetNum].transform.position.y, 0);
    }
}