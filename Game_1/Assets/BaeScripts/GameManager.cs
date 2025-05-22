using BaeScripts.Spawner;
using UnityEngine;

namespace BaeScripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private EnemySpawner spawner;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject startPlayerPanel;


        public void StartGame()
        {
            gameOverPanel.SetActive(false);
            startPlayerPanel.SetActive(false);
            spawner.SpawnEnemy();
        }
    }
}
