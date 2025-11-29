using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    private LogicScript logic;
    public TimeTracker timeTracker;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            logic.Levelcomplete();
            if (timeTracker.playTime < PlayerPrefs.GetFloat("Score3") || PlayerPrefs.GetFloat("Score3") == 0f)
            {
                logic.ShowInput();
            }
            
        }
    }
}
