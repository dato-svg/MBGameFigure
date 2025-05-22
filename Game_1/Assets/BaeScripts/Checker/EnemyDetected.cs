using BaeScripts.PlayerRotator;
using BaeScripts.Spawner;
using UnityEngine;

namespace BaeScripts.Checker
{
    public class EnemyDetected : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private EnemySpawner enemySpawner;
        
        private void Awake() => 
            gameOverPanel.SetActive(false);
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                gameOverPanel.SetActive(true);
                enemySpawner.canSpawn = false;
                other.GetComponentInParent<RotateAndShrink>().gameOver = true;
                Destroy(other.transform.parent.gameObject);
                Debug.Log("Game Over");
            }
        }
    }
}
