using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GButton))]
public class GButtonEditor : UnityEditor.UI.ButtonEditor
{
    private GButton _gButton;

    protected void OnEnable()
    {
        base.OnEnable();
        _gButton = (GButton) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();
        serializedObject.Update();

        var prop_ScaleAnim = this.serializedObject.FindProperty("scaleAnim");
        EditorGUILayout.PropertyField(prop_ScaleAnim);
        if (prop_ScaleAnim.boolValue)
        {
            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("clickDownScale"));
            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("normalScale"));
        }

        var prop_Sound = this.serializedObject.FindProperty("sound");
        EditorGUILayout.PropertyField(prop_Sound);
        if (prop_Sound.boolValue)
        {
            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("clickEffect"));
        }

        serializedObject.ApplyModifiedProperties();
    }
}
