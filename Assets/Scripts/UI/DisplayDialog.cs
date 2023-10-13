using System.Collections.Generic;
using UnityEngine;
using TMPro; // Dodaj tê przestrzeñ nazw
using UnityEngine.SceneManagement;

public class DisplayTextOnSpace : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText1;
    [SerializeField] private TextMeshProUGUI displayText2;
    [SerializeField] private List<string> texts1 = new List<string>();
    [SerializeField] private List<string> texts2 = new List<string>();


    private int currentIndex = 0;
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextText();
        }
    }

    private void DisplayNextText()
    {
        if (currentIndex < texts1.Count)
        {
            displayText1.text = texts1[currentIndex];
            displayText2.text = texts2[currentIndex];
            currentIndex++;
        }
        else
        {
            SceneManager.LoadScene("End", LoadSceneMode.Single);
        }
    }
}
