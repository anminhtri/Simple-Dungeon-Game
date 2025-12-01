using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class Stats : ScriptableObject
{
    public int maxHealth;
    [System.NonSerialized]
    public int curHealth;
    public int dmg;
}
