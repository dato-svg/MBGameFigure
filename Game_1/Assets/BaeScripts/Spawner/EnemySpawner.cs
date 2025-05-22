using UnityEngine;

namespace BaeScripts.Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] enemy;
        public bool canSpawn = true;
        
        
        public void SpawnEnemy()
        {
            if (canSpawn)
            {
                int index = Random.Range(0,enemy.Length);
                GameObject currentEnemy = Instantiate(enemy[index],Vector3.zero, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            }
        }
    }
}