using System.Collections.Generic;
using UnityEngine;

namespace Edgar.Unity
{
    // Class representing a single exfiltration point
    public class ExfilPoint
    {
        public Vector3 Location { get; private set; }
        public List<string> RequiredItems { get; private set; }
        public List<string> RequiredEnemiesDefeated { get; private set; }

        public ExfilPoint(Vector3 location, List<string> requiredItems, List<string> requiredEnemiesDefeated)
        {
            Location = location;
            RequiredItems = requiredItems;
            RequiredEnemiesDefeated = requiredEnemiesDefeated;
        }
    }

    // Manager class for handling exfiltration points
    public class ExfilManager : MonoBehaviour
    {
        private List<ExfilPoint> exfilPoints;
        private KeyManager keyManager; // Assuming keys are part of required items
        private EnemySpawnManager enemySpawnManager; // Assuming it can track defeated enemies

        private void Awake()
        {
            exfilPoints = new List<ExfilPoint>();
            keyManager = FindObjectOfType<KeyManager>();
            enemySpawnManager = FindObjectOfType<EnemySpawnManager>();

            if (keyManager == null || enemySpawnManager == null)
            {
                Debug.LogError("KeyManager or EnemySpawnManager not found in the scene.");
                return;
            }
        }

        // Method to add a new exfiltration point
        public void AddExfilPoint(Vector3 location, List<string> requiredItems, List<string> requiredEnemiesDefeated)
        {
            var exfilPoint = new ExfilPoint(location, requiredItems, requiredEnemiesDefeated);
            exfilPoints.Add(exfilPoint);
        }

        // Method to check if the conditions for exfiltration are met
        public bool CanExfiltrate(ExfilPoint exfilPoint)
        {
            foreach (var item in exfilPoint.RequiredItems)
            {
                if (!keyManager.HasKey(item))
                {
                    Debug.Log($"Missing required item: {item}");
                    return false;
                }
            }

            foreach (var enemy in exfilPoint.RequiredEnemiesDefeated)
            {
                if (!enemySpawnManager.IsEnemyDefeated(enemy))
                {
                    Debug.Log($"Enemy not defeated: {enemy}");
                    return false;
                }
            }

            return true;
        }

        // Method to trigger exfiltration
        public void AttemptExfiltration(Vector3 playerLocation)
        {
            foreach (var exfilPoint in exfilPoints)
            {
                if (Vector3.Distance(playerLocation, exfilPoint.Location) < 1.0f) // Assuming a proximity check
                {
                    if (CanExfiltrate(exfilPoint))
                    {
                        Debug.Log("Exfiltration successful!");
                        // Implement exfiltration logic, e.g., load next level or end game
                    }
                    else
                    {
                        Debug.Log("Exfiltration conditions not met.");
                    }
                }
            }
        }
    }
}
