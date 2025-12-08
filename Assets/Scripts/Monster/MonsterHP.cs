using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    private MechanicScript logic;
    public HealthManager healthManager;
    public Stats monsterStats;
    public GameObject [] hearts;
    public Animator animator;
    public GameObject monsterHP;
    public GameObject monstertrigger1;
    public GameObject monstertrigger2;
    private bool isDying = false;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Mechanic").GetComponent<MechanicScript>();
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
            monsterHP.SetActive(false);
            if (this.gameObject.name == "Mimic 1")
            {
                monstertrigger1.SetActive(false);
            }
            if (this.gameObject.name == "Mimic 2")
            {
                monstertrigger2.SetActive(false);
            }
            monsterStats.curHealth = monsterStats.maxHealth; 
        }
        if (isDying)
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                if (this.gameObject.name == "Mimic 1")
                {
                    logic.OpenDoor1();
                }
                if (this.gameObject.name == "Mimic 2")
                {
                    logic.OpenDoor2();
                }
                this.gameObject.SetActive(false);
            }
        }
    }
}
