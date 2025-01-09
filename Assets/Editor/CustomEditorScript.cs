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
    SerializedProperty newFeature1; // Example new feature
    SerializedProperty newFeature2; // Example new feature

    private void OnEnable()
    {
        playerSpawnPoints = serializedObject.FindProperty("playerSpawnPoints");
        lootTables = serializedObject.FindProperty("lootTables");
        keys = serializedObject.FindProperty("keys");
        lockedDoors = serializedObject.FindProperty("lockedDoors");
        enemySpawns = serializedObject.FindProperty("enemySpawns");
        exfils = serializedObject.FindProperty("exfils");
        newFeature1 = serializedObject.FindProperty("newFeature1");
        newFeature2 = serializedObject.FindProperty("newFeature2");
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
        EditorGUILayout.PropertyField(newFeature1, new GUIContent("New Feature 1"));
        EditorGUILayout.PropertyField(newFeature2, new GUIContent("New Feature 2"));

        serializedObject.ApplyModifiedProperties();
    }
}