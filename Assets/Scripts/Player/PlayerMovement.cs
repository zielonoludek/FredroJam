using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private ActionsEditor playerActions;
    private Rigidbody2D rb;
    private bool jumped = false;

    [SerializeField] private float speed = 5; 

    private void Awake()
    {
        playerActions = new ActionsEditor();
        playerActions.Player.Enable();
        rb = GetComponent<Rigidbody2D>();

        playerActions.Player.Jump.performed += Jump;
        transform.position = Vector3.zero;
    }
    private void FixedUpdate()
    {
        Vector2 playerInput = playerActions.Player.Movement.ReadValue<Vector2>();
        transform.Translate(playerInput * speed * Time.deltaTime);
    }
    private void Jump( InputAction.CallbackContext contex) 
    {
        if (!jumped) 
        {
            jumped = true;
            rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor")) jumped = false; 
    }
}
