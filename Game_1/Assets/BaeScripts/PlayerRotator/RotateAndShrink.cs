using System.Collections;
using BaeScripts.Spawner;
using UnityEngine;

namespace BaeScripts.PlayerRotator
{
    public class RotateAndShrink : MonoBehaviour
    {
        [Header("Rotation Settings")]
        [SerializeField] private Vector3 rotationAxis = Vector3.up;
        [SerializeField] private float rotationSpeed = 180f;

        [Header("Shrink Settings")]
        [SerializeField] private float shrinkSpeed = 0.5f;
        [SerializeField] private float minScale = 0.1f;

        private EnemySpawner _spawner;
        private ScoreUI _scoreUI;
        private Coroutine _actionCoroutine;

        public bool gameOver = false;
        
        private void Start()
        {
            _spawner = FindObjectOfType<EnemySpawner>();
            _scoreUI = FindObjectOfType<ScoreUI>();
            StartEffect();
        }

        
        private void StartEffect()
        {
            if (_actionCoroutine != null) return;
            _actionCoroutine = StartCoroutine(RotateAndShrinkCoroutine());
        }

        private IEnumerator RotateAndShrinkCoroutine()
        {
            while (transform.localScale.x > minScale)
            {
                transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
                
                Vector3 newScale = transform.localScale - Vector3.one * shrinkSpeed * Time.deltaTime;
                newScale = Vector3.Max(newScale, Vector3.one * minScale);
                transform.localScale = newScale;

                yield return null;
            }

            if (gameOver)
            {
                _actionCoroutine = null;
                yield break;
            }
            if (transform.localScale.x <= minScale)
            {
                _spawner.SpawnEnemy();
                _scoreUI.AddScore();
                Destroy(gameObject);
            }

            _actionCoroutine = null;
        }
    }
}