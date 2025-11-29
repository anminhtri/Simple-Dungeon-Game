using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour
{
    public Text score1, score2, score3, name1, name2, name3;
    public TimeTracker timeTracker;
    
    public void LoadLB()
    {
        score1.text = timeTracker.ScoreConv(PlayerPrefs.GetFloat("Score1"));
        score2.text = timeTracker.ScoreConv(PlayerPrefs.GetFloat("Score2"));
        score3.text = timeTracker.ScoreConv(PlayerPrefs.GetFloat("Score3"));

        name1.text = PlayerPrefs.GetString("Name1");
        name2.text = PlayerPrefs.GetString("Name2");
        name3.text = PlayerPrefs.GetString("Name3");

        if (score1.text=="16:40" || score1.text == "00:00")
        {
            score1.text = "---";
        }

        if (score2.text == "16:40" || score2.text == "00:00")
        {
            score2.text = "---";
        }

        if (score3.text == "16:40" || score3.text == "00:00")
        {
            score3.text = "---";
        }

        if (name1.text == "")
        {
            name1.text = "---";
        }
        if (name2.text == "")
        {
            name2.text = "---";
        }
        if (name3.text == "")
        {
            name3.text = "---";
        }
    }
}
