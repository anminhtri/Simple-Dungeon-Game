using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDmg : MonoBehaviour
{
    public HealthManager healthManager;
    public void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("took dmg");
        healthManager.TakeDamage(1);
    }
}
