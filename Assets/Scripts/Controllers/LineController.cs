using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sunbase.Controllers
{
    public class LineController : MonoBehaviour
    {
        public GameObject linePrefab;
        public GameObject currentLine;
        public LineRenderer lineRenderer;
        public EdgeCollider2D edgeCollider;
        public List<Vector2> fingerPoisitions;
        public bool startDraw = false;

        private void Update()
        {
            if (!startDraw) return;
            if (Input.GetMouseButtonUp(0))
            {
                startDraw = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
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
