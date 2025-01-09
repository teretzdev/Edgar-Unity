using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameFeatureManager))]
public class CustomEditorScript : Editor
{
    SerializedProperty playerSpawnPoints;
    SerializedProperty lootTables;
    SerializedProperty keys;
    SerializedProperty lockedDoors;
    SerializedProperty enemySpawns;
    SerializedProperty exfils;

    private void OnEnable()
    {
        playerSpawnPoints = serializedObject.FindProperty("playerSpawnPoints");
        lootTables = serializedObject.FindProperty("lootTables");
        keys = serializedObject.FindProperty("keys");
        lockedDoors = serializedObject.FindProperty("lockedDoors");
        enemySpawns = serializedObject.FindProperty("enemySpawns");
        exfils = serializedObject.FindProperty("exfils");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(playerSpawnPoints, new GUIContent("Player Spawn Points"));
        EditorGUILayout.PropertyField(lootTables, new GUIContent("Loot Tables"));
        EditorGUILayout.PropertyField(keys, new GUIContent("Keys"));
        EditorGUILayout.PropertyField(lockedDoors, new GUIContent("Locked Doors"));
        EditorGUILayout.PropertyField(enemySpawns, new GUIContent("Enemy Spawns"));
        EditorGUILayout.PropertyField(exfils, new GUIContent("Exfils"));

        serializedObject.ApplyModifiedProperties();
    }
}
