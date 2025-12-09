using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    private LogicScript logic;
    public HealthManager healthManager;
    public Stats playerStats;
    public GameObject [] hearts;
    public Animator animator;
    private bool isDying = false;
    private float timer = 0f;
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
            animator.SetTrigger("Die");
            isDying = true;
        }
        if (isDying)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                logic.Dead();
                isDying = false;
                playerStats.curHealth = playerStats.maxHealth;
            }
        }
    }
}
