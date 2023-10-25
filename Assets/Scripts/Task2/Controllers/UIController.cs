using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Sunbase.Task2.Controllers
{
    public class UIController : MonoBehaviour
    {
        [Header("Buttons")]
        public GameObject startButton;
        public GameObject restartButton;

        [Header("Dotween Variables")]
        public float animationDuration = 1f;
        public bool isStartButtonVisible = false;
        public bool isRestartButtonVisible = false;

        public void ToggleStartButton()
        {
            if (isStartButtonVisible)
            {
                startButton.transform.DOMoveY(startButton.transform.position.y - 3.5f, 0.2f);
            }
            else
            {
                startButton.transform.DOMoveY(startButton.transform.position.y + 3.5f, 0.2f);
            }
            isStartButtonVisible = !isStartButtonVisible;
        }

        public void ToggleRestartButton()
        {
            if (isRestartButtonVisible)
            {
                restartButton.transform.DOMoveY(restartButton.transform.position.y - 3.5f, 0.2f);
            }
            else
            {
                restartButton.transform.DOMoveY(restartButton.transform.position.y + 3.5f, 0.2f);
            }
            isRestartButtonVisible = !isRestartButtonVisible;
        }
    }
}

