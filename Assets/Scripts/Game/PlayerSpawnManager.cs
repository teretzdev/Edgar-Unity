using System.Collections.Generic;
using UnityEngine;

namespace Edgar.Unity
{
    // Class representing a single player spawn point
    public class PlayerSpawnPoint
    {
        public Vector3 Location { get; private set; }
        public string Metadata { get; private set; }

        public PlayerSpawnPoint(Vector3 location, string metadata)
        {
            Location = location;
            Metadata = metadata;
        }
    }

    // Manager class for handling player spawn points
    public class PlayerSpawnManager : MonoBehaviour
    {
        private List<PlayerSpawnPoint> spawnPoints;

        public PlayerSpawnManager()
        {
            spawnPoints = new List<PlayerSpawnPoint>();
        }

        // Method to add a new spawn point
        public void AddSpawnPoint(Vector3 location, string metadata)
        {
            var spawnPoint = new PlayerSpawnPoint(location, metadata);
            spawnPoints.Add(spawnPoint);
        }

        // Method to get a random spawn point
        public PlayerSpawnPoint GetRandomSpawnPoint()
        {
            if (spawnPoints.Count == 0)
            {
                Debug.LogWarning("No spawn points available.");
                return null;
            }

            int randomIndex = Random.Range(0, spawnPoints.Count);
            return spawnPoints[randomIndex];
        }

        // Method to configure spawn points manually
        public void ConfigureSpawnPoints(List<Vector3> locations, List<string> metadataList)
        {
            if (locations.Count != metadataList.Count)
            {
                Debug.LogError("Locations and metadata lists must have the same length.");
                return;
            }

            spawnPoints.Clear();
            for (int i = 0; i < locations.Count; i++)
            {
                AddSpawnPoint(locations[i], metadataList[i]);
            }
        }
    }
}
