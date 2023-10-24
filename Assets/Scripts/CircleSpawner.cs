using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circlePrefab;
    public int minCircles = 5;
    public int maxCircles = 10;
    public Transform parent;

    private void Start()
    {
        SpawnRandomCircles();
    }

    public void SpawnRandomCircles()
    {
        int numCircles = Random.Range(minCircles, maxCircles + 1);
        for (int i = 0; i < numCircles; i++)
        {
            float x = Random.Range(-8f, 8f);
            float y = Random.Range(-4f, 4f);
            Instantiate(circlePrefab, parent);
        }
    }
}
