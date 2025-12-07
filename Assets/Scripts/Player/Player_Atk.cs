using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Atk : MonoBehaviour
{
    public HealthManager healthManager;
    public Stats playerStats;
    public Stats monsterStats;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            monsterStats.curHealth = healthManager.TakeDamage(monsterStats, playerStats.dmg);
        }
    }
}