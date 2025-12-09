using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class LocalizationWindow : EditorWindow
{
    private List<Language> languages = new List<Language>();
    private Vector2 scrollPos;

    [MenuItem("My Custom Tools/Localization Tool")]
    public static void Open()
    {
        GetWindow<LocalizationWindow>("Localization Tool");
    }

    private void OnEnable()
    {
        LoadLanguages();
    }

    private void LoadLanguages()
    {
        languages = AssetDatabase.FindAssets("t:Language")
            .Select(guid => AssetDatabase.LoadAssetAtPath<Language>(AssetDatabase.GUIDToAssetPath(guid)))
            .ToList();
        SortEngFirst();
        Sync();
        SortKeysAlphabetically();
    }

    private void OnGUI()
    {
        if (languages.Count == 0)
        {
            EditorGUILayout.HelpBox("No language files found. Create them from Language.cs", MessageType.Warning);
            if (GUILayout.Button("Refresh"))
                LoadLanguages();
            return;
        }

        if (GUILayout.Button("Refresh Language List"))
            LoadLanguages();

        EditorGUILayout.Space();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        DrawKeysTable();
        EditorGUILayout.EndScrollView();
        EditorGUILayout.Space();
        DrawAddKeyButton();
    }

    private void DrawKeysTable()
    {
        var wrapStyle = new GUIStyle(EditorStyles.textArea);
        wrapStyle.wordWrap = true;
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Key", GUILayout.Width(150));

        foreach (var lang in languages)
            lang.languageName = EditorGUILayout.TextField(lang.languageName, GUILayout.Width(150));
        
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        if (languages[0].dictionary != null)
        {
            for (int i = 0; i < languages[0].dictionary.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                languages[0].dictionary[i].key = EditorGUILayout.TextArea(languages[0].dictionary[i].key, wrapStyle, GUILayout.Width(150));

                foreach (var lang in languages)
                {
                    EditorGUILayout.BeginHorizontal();
                    lang.dictionary[i].key = languages[0].dictionary[i].key;
                    lang.dictionary[i].placeholder = EditorGUILayout.TextArea(lang.dictionary[i].placeholder, wrapStyle, GUILayout.Width(150));
                    EditorGUILayout.EndVertical();
                }

                if (GUILayout.Button("X", GUILayout.Width(25)))
                {
                    DeleteKey(i);
                    EditorGUILayout.EndHorizontal();
                    return;
                }

                EditorGUILayout.EndHorizontal();
            }
        }
    }

    private void DrawAddKeyButton()
    {
        EditorGUILayout.Space();

        if (GUILayout.Button("Add New Key"))
        {
            AddKey();
        }
    }

    private void AddKey()
    {
        string newKey = "New Key" + languages[0].dictionary.Count;

        foreach (var lang in languages)
        {
            lang.dictionary.Add(new Language.Dict
            {
                key = newKey,
                placeholder = ""
            });

            EditorUtility.SetDirty(lang);
        }
    }

    private void DeleteKey(int index)
    {
        foreach (var lang in languages)
        {
            lang.dictionary.RemoveAt(index);
            EditorUtility.SetDirty(lang);
        }
    }
    private void SortEngFirst()
    {
        if (languages == null || languages.Count == 0)
        return;

        Language english = languages.FirstOrDefault(l => l.languageName == "English");
        if (english != null)
        {
            languages.Remove(english);
            languages.Insert(0, english);
        }
    }
    private void Sync()
    {
        if (languages == null || languages.Count <= 1)
        return;
        foreach (var lang in languages.Skip(1))
        {
            while (lang.dictionary.Count > languages[0].dictionary.Count)
            {
                lang.dictionary.RemoveAt(languages[0].dictionary.Count);
                EditorUtility.SetDirty(lang);
            }
            while (lang.dictionary.Count < languages[0].dictionary.Count)
            {
                lang.dictionary.Add(new Language.Dict
                {
                    key = "",
                    placeholder = ""
                });
                EditorUtility.SetDirty(lang);
            }
        }
    }
    private void SortKeysAlphabetically()
    {
        languages[0].dictionary.Sort((a, b) => string.Compare(a.key, b.key));

        for (int i = 1; i < languages.Count; i++)
        {
            Language other = languages[i];

            List<Language.Dict> newList = new List<Language.Dict>();

            foreach (var entry in languages[0].dictionary)
            {
                var match = other.dictionary.Find(x => x.key == entry.key);

                if (match != null)
                    newList.Add(match);
                else
                {
                    newList.Add(new Language.Dict
                    {
                        key = entry.key,
                        placeholder = ""
                    });
                }
            }

            other.dictionary = newList;
        }

        foreach (var lang in languages)
            EditorUtility.SetDirty(lang);
    }

}
