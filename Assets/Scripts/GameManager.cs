using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public bool gameEnded = false;
    public int level = 0;
    public GameObject[] rooms;
    public GameObject[] tutorials;
    public GameObject screenEnd;
    public TextMeshProUGUI textScore;
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
    }
    private void OnEnable()
    {
        PlayerController.OnPlayerStartedMoving += HideTutorial;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerStartedMoving -= HideTutorial;
    }
    private void HideTutorial()
    {
        if (tutorials[0] != null)
        {
            tutorials[0].SetActive(false);
        }
        gameStarted = true;
        InvokeRepeating("SetTimer", 1, 1);
    }
    public void Update()
    {

    }
    public void RestartGame()
    {
        timerVal = 30;
        Application.LoadLevel(Application.loadedLevelName);
    }
    public void SetTimer()
    {
        timerVal--;
        textScore.text = timerVal.ToString();
        if (timerVal == 0)
        {
            gameEnded = true;
            CancelInvoke();
            screenEnd.SetActive(true);
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
