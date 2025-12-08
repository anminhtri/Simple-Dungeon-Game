using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    private LogicScript logic;
    public HealthManager healthManager;
    public Stats monsterStats;
    public GameObject [] hearts;
    public Animator animator;
    private bool isDying = false;
    private float timer = 0f;
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
            animator.SetTrigger("Die");
            isDying = true;
            timer = 0f;           
            monsterStats.curHealth = monsterStats.maxHealth;
        }
        if (isDying)
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                this.gameObject.SetActive(false);
                monsterStats.curHealth = monsterStats.maxHealth;
            }
        }
    }
}
