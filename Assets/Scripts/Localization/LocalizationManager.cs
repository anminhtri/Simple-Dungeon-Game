using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{   
    
    public static List<DisplayText> allDisplayText = new List<DisplayText>();
    public Language currentLanguage;

    public void OnValidate()
    {
        foreach (DisplayText displayText in allDisplayText)    
        if (displayText.currentLanguage != null)
        {
            displayText.currentLanguage = currentLanguage;
        }
    }
}
