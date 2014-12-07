using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomPropertyDrawer (typeof(Credits.Member))]
public class MemberPropertyDrawer : PropertyDrawer 
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty (position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), label);

        // Don't make child fields be indented
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        Rect nameRect = new Rect(position.x, position.y, position.width * 0.5f - 12, position.height);
        Rect positionRect = new Rect(position.x + position.width * 0.5f, position.y, position.width * 0.5f - 12, position.height);

        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("m_name"), GUIContent.none);
        EditorGUI.PropertyField(positionRect, property.FindPropertyRelative("m_position"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty ();
    }
}
