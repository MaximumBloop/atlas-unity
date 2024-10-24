using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterStats))]
public class CharacterStatsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CharacterStats character = (CharacterStats)target;

        // Character Name
        EditorGUILayout.LabelField("Character Info", EditorStyles.boldLabel);
        character.characterName = EditorGUILayout.TextField("Name", character.characterName);

        // Stats
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Stats", EditorStyles.boldLabel);
        character.health = EditorGUILayout.IntSlider("Health", character.health, 0, 100);
        character.attack = EditorGUILayout.IntField("Attack", character.attack);
        character.defense = EditorGUILayout.IntField("Defense", character.defense);
        character.experience = EditorGUILayout.IntSlider("Experience", character.experience, 0, 100);
        character.level = EditorGUILayout.IntField("Level", character.level);

        // Health
        if (character.health < 20)
        {
            EditorGUILayout.HelpBox("Warning: Low health!", MessageType.Warning);
        }

        // Level Up
        if (character.experience == 100)
        {
            character.experience = 0;
            character.level += 1;
        }

        // Save changes to the object
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
