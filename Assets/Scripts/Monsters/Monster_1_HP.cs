using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_1_HP : MonoBehaviour
{
    private LogicScript logic;
    public HealthManager healthManager;
    public Stats monsterStats;
    public GameObject [] hearts;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        monsterStats.curHealth = monsterStats.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthManager.UpdateHearts(monsterStats, hearts);
        if (monsterStats.curHealth == 0)
        {
            this.gameObject.SetActive(false);
            monsterStats.curHealth = monsterStats.maxHealth;
        }
    }
}
