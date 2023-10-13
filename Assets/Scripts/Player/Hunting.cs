using Unity.VisualScripting;
using UnityEngine;

public class Hunting : MonoBehaviour
{
    [SerializeField] private PlayerData data;
    [SerializeField] private GameObject openDoor;
    [SerializeField] private GameObject canvas;

    private void Awake()
    {
        openDoor.GetComponent<Collider2D>().enabled = false;
        canvas.SetActive(false);
    }

    private void Update()
    {
        if (data.animalNumber == 10)
        {
            Debug.Log("ok");

            openDoor.GetComponent<Collider2D>().enabled = true;
            gameObject.SetActive(false);
            canvas.SetActive(true);
        }
    }
}
