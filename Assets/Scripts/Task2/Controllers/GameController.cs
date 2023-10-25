using Sunbase.Task2.Class;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sunbase.Task2.Controllers
{
    public class GameController : MonoBehaviour
    {
        public GameObject circlePrefab;
        private int minCircles = 5, maxCircles = 10;
        public Vector2 positiveAxis;
        public Vector2 negativeAxis;
        public List<GameObject> spawnedObjects;
        public LineController lineController;
        public UIController uiController;
        private void Start()
        {
            // start spawing all the circles
            // SpawnCircles();
        }

        public void SpawnCircles()
        {
            int numCircles = Random.Range(minCircles, maxCircles + 1);
            for (int i = 0; i < numCircles; i++)
            {
                float xPos = Random.Range(negativeAxis.x, positiveAxis.x);
                float yPos = Random.Range(negativeAxis.y, positiveAxis.y);
                GameObject generateCircle = Instantiate(circlePrefab, new Vector3(xPos, yPos, 0f), Quaternion.identity);
                spawnedObjects.Add(generateCircle);
                generateCircle.name = "Circle " + i.ToString();
            }
            lineController.startDraw = true;
        }

        public void DeleteTouchings()
        {
            foreach (var obj in spawnedObjects)
            {
                CircleClass circle = obj.GetComponent<CircleClass>();
                if (circle.shouldDestroy)
                {
                    // spawnedObjects.Remove(obj);
                    // DestroyImmediate(obj);
                    Destroy(obj);
                }
            }
            DestroyImmediate(lineController.currentLine);
            StartCoroutine(DelayForRestart());
        }

        IEnumerator DelayForRestart()
        {
            yield return new WaitForSeconds(0.5f);
            uiController.ToggleRestartButton();
        }

        public void RestartButtonClicked()
        {
            foreach (var obj in spawnedObjects)
            {
                if (obj != null)
                {
                    Destroy(obj);
                }
            }
            spawnedObjects = new List<GameObject>();
            lineController.startDraw = false;
            lineController.oneLineDrawed = false;
            uiController.ToggleStartButton();
        }
    }
}