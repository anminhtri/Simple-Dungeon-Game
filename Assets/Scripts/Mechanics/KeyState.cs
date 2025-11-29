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
            // if (gameObject.name == "Yellow Key")
            // {
            //     logic.PickupYellowKey();
            // }
            // else if (gameObject.name == "Blue Key")
            // {
            //     logic.PickupBlueKey();
            // }
            // else if (gameObject.name == "Red Key")
            // {
            //     logic.PickupRedKey();
            // }
        } 
    }
}
