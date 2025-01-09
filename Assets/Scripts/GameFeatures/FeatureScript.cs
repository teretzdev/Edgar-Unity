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
    public List<GameObject> PlayerSpawnPoints => playerSpawnPoints;
    public List<ScriptableObject> LootTables => lootTables;
    public List<GameObject> Keys => keys;
    public List<GameObject> LockedDoors => lockedDoors;
    public List<GameObject> EnemySpawns => enemySpawns;
    public List<GameObject> Exfils => exfils;

    // You can add methods here to manipulate these features if needed
}