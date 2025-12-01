using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private MechanicScript logic;
    public HealthManager healthManager;
    public Stats playerStats;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Mechanic").GetComponent<MechanicScript>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            logic.PickupItem(this.gameObject);
            healthManager.Heal(playerStats, playerStats.maxHealth);
        } 
    }
}
