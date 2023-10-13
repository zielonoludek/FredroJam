using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private ActionsEditor playerActions;

    private void Awake()
    {
        playerActions = new ActionsEditor();
        playerActions.Gun.Enable();

        playerActions.Gun.Click.performed += OnClick;
    }

    private void OnClick(InputAction.CallbackContext contex)
    {
        Instantiate(bullet);
    }
}