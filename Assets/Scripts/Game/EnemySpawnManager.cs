using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Edgar.Unity
{
    // Class representing a single enemy spawn point
    public class EnemySpawnPoint
    {
        public Vector3 Location { get; private set; }
        public float SpawnDelay { get; private set; }
        public string EnemyType { get; private set; }

        public EnemySpawnPoint(Vector3 location, float spawnDelay, string enemyType)
        {
            Location = location;
            SpawnDelay = spawnDelay;
            EnemyType = enemyType;
        }
    }

    // Manager class for handling enemy spawn points
    public class EnemySpawnManager : MonoBehaviour
    {
        private List<EnemySpawnPoint> spawnPoints;
        private Dictionary<string, GameObject> enemyPrefabs;

        private void Awake()
        {
            spawnPoints = new List<EnemySpawnPoint>();
            enemyPrefabs = new Dictionary<string, GameObject>();
            LoadEnemyPrefabs();
        }

        // Method to load enemy prefabs
        private void LoadEnemyPrefabs()
        {
            // Load enemy prefabs from Resources or any other method
            // Example: enemyPrefabs["Zombie"] = Resources.Load<GameObject>("Enemies/Zombie");
        }

        // Method to add a new enemy spawn point
        public void AddSpawnPoint(Vector3 location, float spawnDelay, string enemyType)
        {
            var spawnPoint = new EnemySpawnPoint(location, spawnDelay, enemyType);
            spawnPoints.Add(spawnPoint);
        }

        // Method to start spawning enemies
        public void StartSpawning()
        {
            foreach (var spawnPoint in spawnPoints)
            {
                StartCoroutine(SpawnEnemy(spawnPoint));
            }
        }

        // Coroutine to spawn an enemy at a given spawn point
        private IEnumerator SpawnEnemy(EnemySpawnPoint spawnPoint)
        {
            yield return new WaitForSeconds(spawnPoint.SpawnDelay);

            if (enemyPrefabs.TryGetValue(spawnPoint.EnemyType, out GameObject enemyPrefab))
            {
                Instantiate(enemyPrefab, spawnPoint.Location, Quaternion.identity);
                Debug.Log($"Spawned {spawnPoint.EnemyType} at {spawnPoint.Location}");
            }
            else
            {
                Debug.LogError($"Enemy type {spawnPoint.EnemyType} not found.");
            }
        }
    }
}
