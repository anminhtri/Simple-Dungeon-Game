using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DisplayText))]
public class DisplayTextEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DisplayText dt = (DisplayText)target;

        if (dt.currentLanguage != null && dt.currentLanguage.dictionary != null && dt.currentLanguage.dictionary.Count > 0)
        {
            string[] options = dt.currentLanguage.dictionary.ConvertAll(e => e.key).ToArray();

            int currentIndex = System.Array.IndexOf(options, dt.key);
            if (currentIndex < 0) currentIndex = 0;

            int newIndex = EditorGUILayout.Popup("Key", currentIndex, options);

            dt.key = options[newIndex];
        }
        else
        {
            dt.key = EditorGUILayout.TextField("Key", dt.key);
        }

        DrawDefaultInspector();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(dt);
        }
    }
}
