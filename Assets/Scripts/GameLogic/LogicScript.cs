using Cinemachine.PostFX;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public GameObject startGame;
    public GameObject finishGame;
    public GameObject pauseGame;
    public GameObject time;
    public GameObject scoreInput;
    public GameObject leaderboard;
    public GameObject dead;
    public GameObject health;
    public Transform cam;
    public static bool isStart = false;
    public static bool isControl = false;
    public LoadScore loadScore;
    private PostProcessLayer layer;

    public void Start()
    {
        layer = cam.GetComponent<PostProcessLayer>();
        if (isStart == false)
        {
            startGame.SetActive(true);
            time.SetActive(false);
            TimeFreeze();
        }
    }
    public void TimeFlow()
    {
        isControl = true;
        layer.enabled = false;
        health.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
    public void TimeFreeze()
    {
        isControl = false;
        layer.enabled = true;
        health.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
    public void Startgame()
    {
        startGame.SetActive(false);
        isStart = true;
        time.SetActive(true);
        TimeFlow();
    }
    public void Restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isStart = true;
        time.SetActive(true);
        TimeFlow();
    }
    public void Levelcomplete()
    {
        isStart = false;
        finishGame.SetActive(true);
        TimeFreeze();
    }
    public void Quitgame()
    {
        Application.Quit();
    }
    public void Continue()
    {
        pauseGame.SetActive(false);
        TimeFlow();
    }
    public void Pause()
    {
        pauseGame.SetActive(true);
        TimeFreeze();
    }
    public void QuittoMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isStart = false;
        TimeFreeze();
    }
    public void Dead()
    {
        dead.SetActive(true);
        TimeFreeze();
    }
    public void ShowInput()
    {
        scoreInput.SetActive(true);
    }
    public void HideInput()
    {
        scoreInput.SetActive(false);
    }
    public void ShowLB()
    {
        loadScore.LoadLB();
        leaderboard.SetActive(true);
    }
    public void HideLB()
    {
        leaderboard.SetActive(false);
    }
    public void ResetAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("All PlayerPrefs cleared!");
    }
}
