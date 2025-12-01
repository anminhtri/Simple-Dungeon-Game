using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    private LogicScript logic;
    public HealthManager healthManager;
    public Stats playerStats;
    public GameObject [] hearts;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        playerStats.curHealth = playerStats.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthManager.UpdateHearts(playerStats, hearts);
        if (playerStats.curHealth == 0)
        {
            logic.Dead();
            playerStats.curHealth = playerStats.maxHealth;
        }
    }
}
