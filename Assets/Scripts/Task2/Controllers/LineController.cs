using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sunbase.Task2.Controllers
{
    public class LineController : MonoBehaviour
    {
        public GameObject linePrefab;
        public GameObject currentLine;
        public LineRenderer lineRenderer;
        public EdgeCollider2D edgeCollider;
        public bool startDraw = false;
        public bool oneLineDrawed = false;
        public UIController uiController;
        public GameController gameController;
        public List<Vector2> fingerPoisitions;

        private void Update()
        {
            if (!startDraw) return;
            if (Input.GetMouseButtonUp(0) && oneLineDrawed)
            {
                Debug.Log("Button donw");
                startDraw = false;
                gameController.DeleteTouchings();
            }
            if (Input.GetMouseButtonDown(0))
            {
                oneLineDrawed = true;
                CreateLine();
            }
            if (Input.GetMouseButton(0))
            {
                Vector2 tempFingerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(tempFingerPosition, fingerPoisitions[fingerPoisitions.Count - 1]) > 0.1f)
                {
                    UpdateLine(tempFingerPosition);
                }
            }
        }

        void CreateLine()
        {
            Debug.Log("Called only once1");
            currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
            lineRenderer = currentLine.GetComponent<LineRenderer>();
            edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
            fingerPoisitions.Clear();
            fingerPoisitions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            fingerPoisitions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            lineRenderer.SetPosition(0, fingerPoisitions[0]);
            lineRenderer.SetPosition(1, fingerPoisitions[1]);
            edgeCollider.points = fingerPoisitions.ToArray();
            
        }

        void UpdateLine(Vector2 newFingerPosition)
        {
            fingerPoisitions.Add(newFingerPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPosition);
            edgeCollider.points = fingerPoisitions.ToArray();
        }
    }
}
