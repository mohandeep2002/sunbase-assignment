using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> linePositions = new List<Vector3>();
    private Collider2D[] hitColliders;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ResetLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            linePositions.Add(mousePos);
            lineRenderer.positionCount = linePositions.Count;
            lineRenderer.SetPositions(linePositions.ToArray());
        }
        if (Input.GetMouseButtonUp(0))
        {
            hitColliders = Physics2D.OverlapAreaAll(linePositions[0], linePositions[linePositions.Count - 1]);
            foreach (var collider in hitColliders)
            {
                Debug.Log(collider.name);
                if (collider.CompareTag("Circle"))
                {
                    Destroy(collider.gameObject);
                }
            }
            ResetLine();
        }
    }

    private void ResetLine()
    {
        linePositions.Clear();
        lineRenderer.positionCount = 0;
    }
}
