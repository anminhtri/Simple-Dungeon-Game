using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyState : MonoBehaviour
{
    private MechanicScript logic;
    public bool gotKey = false;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Mechanic").GetComponent<MechanicScript>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gotKey = true;
            logic.PickupItem(this.gameObject);
        } 
    }
}
