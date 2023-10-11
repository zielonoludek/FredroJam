using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    private Camera camera;
    [SerializeField] private Vector3 target;
    private float speed = 100;
    private Rigidbody2D rb;
    private BulletSpawner gun;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = FindObjectOfType<Camera>();
        gun = FindObjectOfType<BulletSpawner>();
    }
    public void Start()
    {
        transform.position = gun.transform.position;
        target = camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        rb.AddForce((target - transform.position) * speed);
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("RenderArea")) Destroy(gameObject);
    }
}
