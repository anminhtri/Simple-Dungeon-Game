using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class DisplayText : MonoBehaviour
{
    public Text displayText;
    
    public Language currentLanguage;
    public string key;
    
    public void OnEnable()
    {
        LocalizationManager.allDisplayText.Add(this);
    }
    public void Update()
    {  
        if (currentLanguage != null)
        foreach (var entry in currentLanguage.dictionary)
        {
            if (entry.key == key)
            {
                displayText.text = entry.placeholder;
                return;
            }
        } 
    }
}
