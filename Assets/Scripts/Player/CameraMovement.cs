using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    private void Awake()
    {
        player = FindFirstObjectByType<PlayerMovement>(); 
    }
    private void Update()
    {
        if ((player.transform.position.x) < 22f && (player.transform.position.x) > -18 ) transform.position = new Vector3(player.transform.position.x, 3,-1);
    }
}
