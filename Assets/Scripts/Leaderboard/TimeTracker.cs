using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTracker : MonoBehaviour
{
    public Text time;
    public float playTime = 0f;

    // Update is called once per frame
    void Update()
    {
        playTime += Time.deltaTime;
        time.text = ScoreConv(playTime);
    }
    public string ScoreConv(float playTime)
    {
    int minutes = Mathf.FloorToInt(playTime / 60);
    int seconds = Mathf.FloorToInt(playTime % 60);
    return $"{minutes:00}:{seconds:00}";
    }
}
