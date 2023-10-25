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
            }
            lineController.startDraw = true;
        }
    }
}