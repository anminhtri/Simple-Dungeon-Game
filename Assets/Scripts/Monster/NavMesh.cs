using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    public NavMeshAgent agent1;
    public NavMeshAgent agent2;
    public Transform player;
    public MonsterHpTrigger check1;
    public MonsterHpTrigger check2;
    public MonsterAtkTrigger atkCheck1;
    public MonsterAtkTrigger atkCheck2;
    public MonsterHP isDying1;
    public MonsterHP isDying2;

    void Update()
    {
        if (check1.playerCheck == true && atkCheck1.atkCheck == false && isDying1.isDying == false && this.gameObject.name == "Mimic 1")
        {
            agent1.SetDestination(player.position);
        }
        else if (isDying1.isDying == false)
        {
            agent1.ResetPath();
        }
        if (check2.playerCheck == true && atkCheck2.atkCheck == false && isDying2.isDying == false && this.gameObject.name == "Mimic 2")
        {
            agent2.SetDestination(player.position);
        }
        else if (isDying1.isDying == false)
        {
            agent2.ResetPath();
        }
    }
}
