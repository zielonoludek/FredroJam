using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningAnimal : Animal
{
    private Vector3 target;
    private int targetNum;
    [SerializeField] private GameObject targetList;

    private void Start()
    {
        renderArea = GameObject.FindGameObjectWithTag("RenderArea");
        targetList = GameObject.FindGameObjectWithTag("FoxTargets");
        GetChildren(targetList);
        RandomiseTarget();
    }
    private void Update() => Move(target);
    private void RandomiseTarget()
    {
        targetNum = Random.Range(1, childNum +1);
        target = new Vector3(childList[targetNum].transform.position.x, -0.5f , 0);
    }
}