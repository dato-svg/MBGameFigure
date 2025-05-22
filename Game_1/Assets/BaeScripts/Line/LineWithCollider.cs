using UnityEngine;

namespace BaeScripts.Line
{
    [RequireComponent(typeof(LineRenderer))]
    [RequireComponent(typeof(EdgeCollider2D))]
    public class LineWithCollider : MonoBehaviour
    {
        private LineRenderer _lineRenderer;
        private EdgeCollider2D _edgeCollider;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _edgeCollider = GetComponent<EdgeCollider2D>();
        }

        private void Start()
        {
            UpdateCollider();
        }

        public void UpdateCollider()
        {
            int pointCount = _lineRenderer.positionCount;
            Vector2[] colliderPoints = new Vector2[pointCount];

            for (int i = 0; i < pointCount; i++)
            {
                Vector3 worldPos = _lineRenderer.GetPosition(i);
                colliderPoints[i] = new Vector2(worldPos.x, worldPos.y);
            }

            _edgeCollider.points = colliderPoints;
        }
    }
}