using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{   
    
    public static List<DisplayText> allDisplayText = new List<DisplayText>();
    public Language currentLanguage;
    public Language english;
    public Language french;

    public void OnValidate()
    {
        SetLanguage(currentLanguage);
    }

    public void Awake()
    {
        LoadSavedLanguage();
    }

    public void SetLanguage(Language setLanguage)
    {
        currentLanguage = setLanguage;
        allDisplayText = GetAllDisplayTexts();
        foreach (DisplayText displayText in allDisplayText)    
        if (displayText.currentLanguage != null)
        {
            displayText.currentLanguage = currentLanguage;
        }
    }

    public static List<DisplayText> GetAllDisplayTexts()
    {
        List<DisplayText> result = new List<DisplayText>();

        var all = Resources.FindObjectsOfTypeAll<DisplayText>();

        foreach (var dt in all)
        {
            // Only scene objects (not assets)
            if (dt.gameObject.scene.IsValid())
                result.Add(dt);
        }

        return result;
    }
    public void OnChooseEnglish()
    {
        PlayerPrefs.SetString("Language", "English");
        PlayerPrefs.Save();
    }

    public void OnChooseFrench()
    {
        PlayerPrefs.SetString("Language", "French");
        PlayerPrefs.Save();
    }
    public void LoadSavedLanguage()
    {
        string lang = PlayerPrefs.GetString("Language", "English");

        if (lang == "English")
            SetLanguage(english);
        else if (lang == "French")
            SetLanguage(french);
    }
}
