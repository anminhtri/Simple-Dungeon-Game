using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public HealthManager healthManager;
    public Stats playerStats;
    public GameObject [] hearts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthManager.UpdateHearts(playerStats, hearts);
    }
}
