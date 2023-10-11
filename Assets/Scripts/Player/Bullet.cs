using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    private Camera camera;
    [SerializeField] private Vector2 target;
    private float speed = 10;

    public void Awake()
    {
        camera = FindObjectOfType<Camera>();
        target = camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target ,speed * Time.deltaTime );
    }
}
