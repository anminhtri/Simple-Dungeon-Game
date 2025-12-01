using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealDmg : MonoBehaviour
{
    public HealthManager healthManager;
    public Stats playerStats;
    public Stats cubeStats;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerStats.curHealth = healthManager.TakeDamage(playerStats, cubeStats.dmg);
        }
    }
}
