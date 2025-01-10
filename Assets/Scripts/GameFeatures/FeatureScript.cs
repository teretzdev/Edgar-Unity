using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameFeatureManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> playerSpawnPoints;

    [SerializeField]
    private List<ScriptableObject> lootTables;

    [SerializeField]
    private List<GameObject> keys;

    [SerializeField]
    private List<GameObject> lockedDoors;

    [SerializeField]
    private List<GameObject> enemySpawns;

    [SerializeField]
    private List<GameObject> exfils;
    [SerializeField]
    private List<GameObject> newFeature1; // Example new feature
    [SerializeField]
    private List<GameObject> newFeature2; // Example new feature

    // Properties to access the fields
    public List<GameObject> PlayerSpawnPoints { get => playerSpawnPoints; set => playerSpawnPoints = value; }
    public List<ScriptableObject> LootTables { get => lootTables; set => lootTables = value; }
    public List<GameObject> Keys { get => keys; set => keys = value; }
    public List<GameObject> LockedDoors { get => lockedDoors; set => lockedDoors = value; }
    public List<GameObject> EnemySpawns { get => enemySpawns; set => enemySpawns = value; }
    public List<GameObject> Exfils { get => exfils; set => exfils = value; }
    public List<GameObject> NewFeature1 { get => newFeature1; set => newFeature1 = value; } // Example new feature
    public List<GameObject> NewFeature2 { get => newFeature2; set => newFeature2 = value; } // Example new feature

    // You can add methods here to manipulate these features if needed
}