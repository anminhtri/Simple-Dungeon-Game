using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveScore : MonoBehaviour
{
    public TMP_InputField inputField;
    public TimeTracker timeTracker;
    private LogicScript logic;

    public void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    public void SetScores()
    {
        List<float> scores = new List<float>();
        List<string> names = new List<string>();

        scores.Add(PlayerPrefs.GetFloat("Score1"));
        scores.Add(PlayerPrefs.GetFloat("Score2"));
        scores.Add(PlayerPrefs.GetFloat("Score3"));

        names.Add(PlayerPrefs.GetString("Name1"));
        names.Add(PlayerPrefs.GetString("Name2"));
        names.Add(PlayerPrefs.GetString("Name3"));

        for (int i = 0; i < 3; i++)
        {
            if(scores[i]<=0)
            {
                scores[i] = 1000f;
            }
            if(timeTracker.playTime < scores[i])
            {
                scores.Insert(i, timeTracker.playTime);
                names.Insert(i, inputField.text);
                break;
            }
        }

        PlayerPrefs.SetFloat("Score1", scores[0]);
        PlayerPrefs.SetFloat("Score2", scores[1]);
        PlayerPrefs.SetFloat("Score3", scores[2]);

        PlayerPrefs.SetString("Name1", names[0]);
        PlayerPrefs.SetString("Name2", names[1]);
        PlayerPrefs.SetString("Name3", names[2]);
        logic.HideInput();
        logic.ShowLB();
    }
}
