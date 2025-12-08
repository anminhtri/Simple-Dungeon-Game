using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHpTrigger : MonoBehaviour
{
    public GameObject monsterHP;
    public Animator animatorMimic1;
    public Animator animatorMimic2;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && this.gameObject.name == "Cube 1")
        {
            monsterHP.SetActive(true);
            animatorMimic1.SetTrigger("IsAlarmed");
            this.gameObject.SetActive(false);
        }
        if (other.CompareTag("Player") && this.gameObject.name == "Cube 2")
        {
            monsterHP.SetActive(true);
            animatorMimic2.SetTrigger("IsAlarmed");
            this.gameObject.SetActive(false);
        }
    }
}
