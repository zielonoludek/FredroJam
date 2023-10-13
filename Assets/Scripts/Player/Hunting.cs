using Unity.VisualScripting;
using UnityEngine;

public class Hunting : MonoBehaviour
{
    [SerializeField] private PlayerData data;
    [SerializeField] private GameObject openDoor;
    [SerializeField] private GameObject canvas;

    private void Awake()
    {
        data.animalNumber = 0;
        gameObject.SetActive(true);
        openDoor.SetActive(false);
        openDoor.GetComponent<Collider2D>().enabled = false;
        canvas.SetActive(false);
    }

    private void Update()
    {
        if (data.animalNumber == 10)
        {
            openDoor.GetComponent<Collider2D>().enabled = true;
            openDoor.SetActive(true);
            gameObject.SetActive(false);
            canvas.SetActive(true);
        }
    }
}
