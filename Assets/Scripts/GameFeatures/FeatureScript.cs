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

    // Properties to access the fields
    public List<GameObject> PlayerSpawnPoints { get => playerSpawnPoints; set => playerSpawnPoints = value; }
    public List<ScriptableObject> LootTables { get => lootTables; set => lootTables = value; }
    public List<GameObject> Keys { get => keys; set => keys = value; }
    public List<GameObject> LockedDoors { get => lockedDoors; set => lockedDoors = value; }
    public List<GameObject> EnemySpawns { get => enemySpawns; set => enemySpawns = value; }
    public List<GameObject> Exfils { get => exfils; set => exfils = value; }

    // You can add methods here to manipulate these features if needed
}