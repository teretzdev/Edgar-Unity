using System;
using UnityEditor;
using UnityEngine;

namespace Edgar.Unity.Editor
{
    [CustomEditor(typeof(DoorsGrid2D))]
    public class DoorsInspector : UnityEditor.Editor
    {
        private HybridDoorModeInspector hybridDoorModeInspector;
        private SimpleDoorModeInspector simpleDoorModeInspector;
        private ManualDoorModeInspector manualDoorModeInspector;

        private SerializedProperty newFeature1Property;
        private SerializedProperty newFeature2Property;
        private SerializedProperty newFeature3Property;
        private SerializedProperty newFeature4Property;

        public void OnEnable()
        {
            var doors = (DoorsGrid2D) target;

            hybridDoorModeInspector = new HybridDoorModeInspector(
                serializedObject,
                doors,
                serializedObject.FindProperty(nameof(DoorsGrid2D.HybridDoorModeData)));
            simpleDoorModeInspector = new SimpleDoorModeInspector(
                serializedObject,
                doors);
            manualDoorModeInspector = new ManualDoorModeInspector(
                serializedObject,
                doors,
                serializedObject.FindProperty(nameof(DoorsGrid2D.ManualDoorModeData)));

            newFeature1Property = serializedObject.FindProperty("NewFeature1");
            newFeature2Property = serializedObject.FindProperty("NewFeature2");
            newFeature3Property = serializedObject.FindProperty("NewFeature3");
            newFeature4Property = serializedObject.FindProperty("NewFeature4");

            SceneView.RepaintAll();
        }

        public void OnSceneGUI()
        {
            var doors = (DoorsGrid2D) target;

            switch (doors.SelectedMode)
            {
                case DoorsGrid2D.DoorMode.Manual:
                    manualDoorModeInspector.OnSceneGUI();
                    break;

                case DoorsGrid2D.DoorMode.Simple:
                    simpleDoorModeInspector.OnSceneGUI();
                    break;

                case DoorsGrid2D.DoorMode.Hybrid:
                    hybridDoorModeInspector.OnSceneGUI();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var doors = (DoorsGrid2D) target;

            var selectedModeProp = serializedObject.FindProperty(nameof(DoorsGrid2D.SelectedMode));
            selectedModeProp.intValue = GUILayout.SelectionGrid((int) doors.SelectedMode, new[]
            {
                "Simple mode",
                "Manual mode",
                "Hybrid mode"
            }, 3);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("New Features", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(newFeature1Property, new GUIContent("New Feature 1"));
            EditorGUILayout.PropertyField(newFeature2Property, new GUIContent("New Feature 2"));
            EditorGUILayout.PropertyField(newFeature3Property, new GUIContent("New Feature 3"));
            EditorGUILayout.PropertyField(newFeature4Property, new GUIContent("New Feature 4"));

            switch (doors.SelectedMode)
            {
                case DoorsGrid2D.DoorMode.Simple:
                    simpleDoorModeInspector.OnInspectorGUI();
                    break;

                case DoorsGrid2D.DoorMode.Manual:
                    manualDoorModeInspector.OnInspectorGUI();
                    break;

                case DoorsGrid2D.DoorMode.Hybrid:
                    hybridDoorModeInspector.OnInspectorGUI();
                    break;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}