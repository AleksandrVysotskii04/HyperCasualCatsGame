using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public bool gameEnded = false;
    public int level = 0;
    public GameObject[] rooms;
    public GameObject[] tutorials;
    public GameObject screenEnd;
    public TextMeshProUGUI textTimer;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textBestScore;
    public TextMeshProUGUI textScoreFinal;
    public int timerVal = 30;
    private void Awake()
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            if (i <= level)
            {
                rooms[i].SetActive(true);
            }
        }
        textBestScore.text = "Best: " + PlayerPrefs.GetInt("scoreMax", 0);
    }
    // private void OnEnable()
    // {
    //     PlayerController.OnPlayerStartedMoving += HideTutorial;
    // }

    // private void OnDisable()
    // {
    //     PlayerController.OnPlayerStartedMoving -= HideTutorial;
    // }
    public void StartGame()
    {
        if (tutorials[0] != null)
        {
            tutorials[0].SetActive(false);
        }
        gameStarted = true;
        InvokeRepeating("SetTimer", 1, 1);

    }
    // private void HideTutorial()
    // {

    // }
    public void Update()
    {

    }
    public void RestartGame()
    {
        int scoreReal = int.Parse(textScore.text);
        int scoreMax = PlayerPrefs.GetInt("scoreMax", 0);
        PlayerPrefs.SetInt("scoreMax", Math.Max(scoreReal, scoreMax));
        timerVal = 30;
        Application.LoadLevel(Application.loadedLevelName);
    }
    public void SetTimer()
    {
        timerVal--;
        textTimer.text = timerVal.ToString();
        if (timerVal == 0)
        {
            gameEnded = true;
            CancelInvoke();
            screenEnd.SetActive(true);
            textScoreFinal.text = "Score: " + textScore.text;
        }
    }
    public void WatchExtraTimeVideo()
    {
        //TODO: Show video ad
        GetExtraTime();
    }
    public void GetExtraTime()
    {
        timerVal = 5;
        InvokeRepeating("SetTimer", 1, 1);
        gameEnded = false;
        screenEnd.SetActive(false);
    }
}
