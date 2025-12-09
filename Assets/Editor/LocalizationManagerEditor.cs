using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LocalizationManager))]
public class LocalizationManagerEditor : Editor
{
    SerializedProperty currentLanguageProp;

    private void OnEnable()
    {
        currentLanguageProp = serializedObject.FindProperty("currentLanguage");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        LocalizationManager manager = (LocalizationManager)target;

        string[] guids = AssetDatabase.FindAssets("t:Language");
        Language[] languages = new Language[guids.Length];
        string[] languageNames = new string[guids.Length];

        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            languages[i] = AssetDatabase.LoadAssetAtPath<Language>(path);
            languageNames[i] = languages[i].languageName;
        }

        int currentIndex = 0;
        if (currentLanguageProp.objectReferenceValue != null)
        {
            currentIndex = System.Array.IndexOf(languages, (Language)currentLanguageProp.objectReferenceValue);
            if (currentIndex < 0) currentIndex = 0;
        }

        int newIndex = EditorGUILayout.Popup("Current Language", currentIndex, languageNames);
        if (languages.Length > 0)
        {
            if ((Language)currentLanguageProp.objectReferenceValue != languages[newIndex])
            {
                currentLanguageProp.objectReferenceValue = languages[newIndex];
            }
        }
        else
        {
            currentLanguageProp.objectReferenceValue = null;
            EditorGUILayout.HelpBox("No Language assets found in project.", MessageType.Warning);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
