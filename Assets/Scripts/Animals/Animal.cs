using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private float hp;

    public void SetHP(float number) => hp = number;
    private void Hit()
    {
        hp -= 1;
        if (hp < 1) Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Bullet")) Hit();
    }
    private void OnDestroy() => Debug.Log("Animal defeated");
}
