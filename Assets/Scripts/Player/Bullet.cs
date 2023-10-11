using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    private Camera camera;
    private Vector3 target;
    private Rigidbody2D rb;
    private BulletSpawner gun;
    private float speed = 1000;

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
        Vector3 force = (target - transform.position).normalized;
        rb.AddForce(force * speed);
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("RenderArea")) Destroy(gameObject);
    }
}
