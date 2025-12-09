using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Language")]
public class Language : ScriptableObject
{
    public string languageName;
    [Serializable]
    public class Dict
    {
        public string key;
        public string placeholder;
    }
    public List<Dict> dictionary = new List<Dict>();
}
