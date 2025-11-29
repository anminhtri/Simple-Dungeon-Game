using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseGame;
    public bool isPause = false;
    private LogicScript logic;
    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    void Update()
    {
        if (LogicScript.isStart == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && isPause == false)
            {
                logic.Pause();
                isPause = true;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isPause == true)
            {
                logic.Continue();
                isPause = false;
            }
        }
    }
}
