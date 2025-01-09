using System.Collections.Generic;
using UnityEngine;

namespace Edgar.Unity
{
    public class GameInitializer : MonoBehaviour
    {
        private PlayerSpawnManager playerSpawnManager;

        private void Awake()
        {
            playerSpawnManager = FindObjectOfType<PlayerSpawnManager>();
            if (playerSpawnManager == null)
            {
                Debug.LogError("PlayerSpawnManager not found in the scene.");
                return;
            }

            InitializePlayerSpawnPoints();
        }

        private void InitializePlayerSpawnPoints()
        {
            List<PlayerSpawnPoint> availableSpawnPoints = GetAvailableSpawnPoints();

            if (availableSpawnPoints.Count == 0)
            {
                Debug.LogError("No available spawn points found.");
                return;
            }

            PlayerSpawnPoint selectedSpawnPoint = SelectSpawnPoint(availableSpawnPoints);
            if (selectedSpawnPoint != null)
            {
                // Logic to position the player at the selected spawn point
                // For example: player.transform.position = selectedSpawnPoint.Location;
                Debug.Log($"Player spawned at: {selectedSpawnPoint.Location}");
            }
        }

        private List<PlayerSpawnPoint> GetAvailableSpawnPoints()
        {
            List<PlayerSpawnPoint> availableSpawnPoints = new List<PlayerSpawnPoint>();

            foreach (var spawnPoint in playerSpawnManager.GetAllSpawnPoints())
            {
                if (IsSpawnPointFree(spawnPoint))
                {
                    availableSpawnPoints.Add(spawnPoint);
                }
            }

            return availableSpawnPoints;
        }

        private bool IsSpawnPointFree(PlayerSpawnPoint spawnPoint)
        {
            // Implement logic to check if the spawn point is free from obstacles or enemies
            // This could involve raycasting or checking for colliders in the area
            // For simplicity, let's assume all points are free
            return true;
        }

        private PlayerSpawnPoint SelectSpawnPoint(List<PlayerSpawnPoint> availableSpawnPoints)
        {
            // Select a random spawn point from the available ones
            int randomIndex = Random.Range(0, availableSpawnPoints.Count);
            return availableSpawnPoints[randomIndex];
        }
    }
}
