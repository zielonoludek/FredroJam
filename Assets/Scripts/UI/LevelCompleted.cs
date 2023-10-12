using System;
using Unity.VisualScripting;
using UnityEngine;

namespace UI
{
    public class LevelCompleted : MonoBehaviour
    {
        [SerializeField] private GameObject levelCompletedUI;

        private void Start()
        {
            levelCompletedUI.SetActive(false);
        }

        public void SetLevelCompleted()
        {
            levelCompletedUI.SetActive(true);
        }
    }
}
