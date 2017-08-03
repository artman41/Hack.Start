using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[CustomEditor(typeof(ClickBehaviour))]
public class ClickBehaviourEditor : Editor {

    public override void OnInspectorGUI() {
        this.serializedObject.Update();

        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("MouseDown"), true);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("MouseUp"), true);

        this.serializedObject.ApplyModifiedProperties();
    }
}
