using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{
    public HealthManager healthManager;
    public Stats playerStats;
    public Stats monsterStats;
    public Stats monsterStats2;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Mimic 1")
        {
            monsterStats.curHealth = healthManager.TakeDamage(monsterStats, playerStats.dmg);
        }
        if (other.gameObject.name == "Mimic 2")
        {
            monsterStats2.curHealth = healthManager.TakeDamage(monsterStats2, playerStats.dmg);
        }
    }
}