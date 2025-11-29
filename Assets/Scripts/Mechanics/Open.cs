using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Open : MonoBehaviour
{
    public KeyState yellowKey;
    public KeyState blueKey;
    public KeyState redKey;
    private MechanicScript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Mechanic").GetComponent<MechanicScript>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && yellowKey.gotKey)
        {
            logic.OpenYellowDoor();
        }
        if (other.CompareTag("Player") && blueKey.gotKey)
        {
            logic.OpenBlueDoor();
        } 
        if (other.CompareTag("Player") && redKey.gotKey)
        {
            logic.OpenRedDoor();
        } 
    }
}
