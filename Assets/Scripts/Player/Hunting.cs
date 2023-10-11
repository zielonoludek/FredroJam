using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hunting : MonoBehaviour
{
    private ActionsEditor playerActions;

    [SerializeField] private float speed = 5;

    private void Awake()
    {
        playerActions = new ActionsEditor();
        playerActions.Gun.Enable();

        playerActions.Gun.Click.performed += OnClick;
        transform.position = Vector3.zero;
    }

    private void OnClick(InputAction.CallbackContext contex)
    {

    }
}
