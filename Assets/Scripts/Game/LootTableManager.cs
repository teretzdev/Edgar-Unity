using System;
using System.Collections.Generic;
using UnityEngine;

namespace Edgar.Unity
{
    // Class representing a single loot item
    public class LootItem
    {
        public string Name { get; private set; }
        public string Category { get; private set; }
        public float Probability { get; private set; }

        public LootItem(string name, string category, float probability)
        {
            Name = name;
            Category = category;
            Probability = probability;
        }
    }

    // Class representing a loot table
    public class LootTable
    {
        private List<LootItem> lootItems;

        public LootTable()
        {
            lootItems = new List<LootItem>();
        }

        // Method to add a new loot item
        public void AddLootItem(string name, string category, float probability)
        {
            var lootItem = new LootItem(name, category, probability);
            lootItems.Add(lootItem);
        }

        // Method to retrieve a random loot item based on probability
        public LootItem GetRandomLootItem()
        {
            float totalProbability = 0f;
            foreach (var item in lootItems)
            {
                totalProbability += item.Probability;
            }

            float randomPoint = UnityEngine.Random.value * totalProbability;
            float currentProbability = 0f;

            foreach (var item in lootItems)
            {
                currentProbability += item.Probability;
                if (randomPoint <= currentProbability)
                {
                    return item;
                }
            }

            return null; // In case no item is found, which should not happen
        }

        // Method to update the loot table with new items
        public void UpdateLootTable(List<LootItem> newItems)
        {
            lootItems.Clear();
            lootItems.AddRange(newItems);
        }
    }

    // Manager class for handling loot tables
    public class LootTableManager : MonoBehaviour
    {
        private LootTable lootTable;

        private void Awake()
        {
            lootTable = new LootTable();
            InitializeLootTable();
        }

        // Method to initialize the loot table with default items
        private void InitializeLootTable()
        {
            lootTable.AddLootItem("Gold Coin", "Currency", 0.5f);
            lootTable.AddLootItem("Health Potion", "Consumable", 0.3f);
            lootTable.AddLootItem("Sword", "Weapon", 0.2f);
        }

        // Method to populate a container with loot items
        public List<LootItem> PopulateContainer(int itemCount)
        {
            List<LootItem> items = new List<LootItem>();
            for (int i = 0; i < itemCount; i++)
            {
                var item = lootTable.GetRandomLootItem();
                if (item != null)
                {
                    items.Add(item);
                }
            }
            return items;
        }
    }
}
