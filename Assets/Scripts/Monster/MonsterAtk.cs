using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAtk : MonoBehaviour
{
    public HealthManager healthManager;
    public Stats playerStats;
    public Stats monsterStats;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerStats.curHealth = healthManager.TakeDamage(playerStats, monsterStats.dmg);
        }
    }
}
