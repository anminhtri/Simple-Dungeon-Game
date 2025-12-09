using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAtkTrigger : MonoBehaviour
{
    public GameObject atkBox;
    public float cooldown = 2f;
    public Animator animator;
    private float lastAtkTime = 0f;
    public bool atkCheck = false;

    void Update()
    {
        if (Time.time - lastAtkTime >= cooldown * 0.3)
        {
            atkBox.SetActive(true);
        }
        if (Time.time - lastAtkTime >= cooldown * 0.4)
        {
            atkBox.SetActive(false);
        }
        if (Time.time - lastAtkTime >= cooldown)
        {
            atkCheck = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Time.time - lastAtkTime > cooldown)
        {
            animator.SetTrigger("Attack");
            lastAtkTime = Time.time;
            atkCheck = true;
        }
    }
}
