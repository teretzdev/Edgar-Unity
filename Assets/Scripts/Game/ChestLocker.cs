using System.Collections.Generic;
using UnityEngine;

namespace Edgar.Unity
{
    public class ChestLocker : MonoBehaviour
    {
        private LootTableManager lootTableManager;
        private List<LootItem> containedItems;

        private void Awake()
        {
            lootTableManager = FindObjectOfType<LootTableManager>();
            if (lootTableManager == null)
            {
                Debug.LogError("LootTableManager not found in the scene.");
                return;
            }

            containedItems = new List<LootItem>();
        }

        // Method to open the chest or locker
        public void OpenContainer(int itemCount)
        {
            if (lootTableManager == null)
            {
                Debug.LogError("LootTableManager is not initialized.");
                return;
            }

            containedItems = lootTableManager.PopulateContainer(itemCount);
            DisplayLootItems();
        }

        // Method to display the loot items retrieved from the container
        private void DisplayLootItems()
        {
            if (containedItems.Count == 0)
            {
                Debug.Log("The container is empty.");
                return;
            }

            Debug.Log("Items retrieved from the container:");
            foreach (var item in containedItems)
            {
                Debug.Log($"- {item.Name} ({item.Category})");
            }
        }
    }
}
