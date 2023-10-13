using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private ActionsEditor playerActions;
    private Rigidbody2D rb;
    private bool jumped = false;

    [SerializeField] private float speed = 5;
    private float jumpModifier = 1.5f;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        playerActions = new ActionsEditor();
        playerActions.Player.Enable();
        rb = GetComponent<Rigidbody2D>();

        playerActions.Player.Jump.performed += Jump;
        transform.position = new Vector3(transform.position.x, 0.7f, 0);
    }
    private void FixedUpdate()
    {
        Vector2 playerInput = playerActions.Player.Movement.ReadValue<Vector2>();
        transform.Translate(playerInput * speed * Time.deltaTime);
        animator.SetFloat("Speed", speed);
    }
    private void Jump(InputAction.CallbackContext contex)
    {
        if (!jumped)
        {
            jumped = true;
            rb.AddForce(Vector2.up * speed * jumpModifier, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor")) jumped = false;
    }
    void OnDisable()
    {
        playerActions.Player.Jump.performed -= Jump;
        playerActions.Player.Jump.Disable();
    }
}
