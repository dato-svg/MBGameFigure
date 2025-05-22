using UnityEngine;

namespace BaeScripts.PlayerRotator
{
    public class RotateOnClick : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 100f;
        [SerializeField] private Vector3 rotationAxis = Vector3.right;

        private bool _isRotating;
        private int _direction = 0;

        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            HandleInput();
            RotateObject();
        }

        private void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;
                Vector3 objectScreenPos = _mainCamera.WorldToScreenPoint(transform.position);

                if (mousePos.x < objectScreenPos.x)
                    _direction = -1;
                else
                    _direction = 1;

                _isRotating = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isRotating = false;
            }
        }

        private void RotateObject()
        {
            if (!_isRotating) return;

            transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime * _direction);
        }
    }
}