using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [Header("Total Tally")]
    public GameManager gameManager;
    // public GameObject spaceShipInventoryManager;
    private int total;

    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Countdown")]
    public int countdownTime;
    public TextMeshProUGUI countdownDisplay;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        StartCoroutine(CountdownToStart());
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);

        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText(time);
            timerText.color = Color.red;
            enabled = false;

            // int total = spaceShipInventoryManager.GetComponent<SpaceShipInventoryManager>().total;
            int total = SpaceShipInventoryManager.total;
            Debug.Log("total in timer is" + total);
            // GetEndScreen(total);
            SceneManager.LoadScene("CutScene2");
        }
        SetTimerText(time);
    }

    private void SetTimerText(TimeSpan time)
    {
        timerText.text = time.ToString("mm':'ss'.'ff");

    }

    IEnumerator CountdownToStart()
    {
        Time.timeScale = 0;
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSecondsRealtime(1f);

            countdownTime--;
        }

        countdownDisplay.text = "GO!";

        gameManager.BeginGame();

        yield return new WaitForSecondsRealtime(1f);

        countdownDisplay.gameObject.SetActive(false);
    }

    private void GetEndScreen(int total){
        if (total == 0){
            SceneManager.LoadSceneAsync(3); //collected no memories
        } else if (total > 0 && total <3500){
            SceneManager.LoadSceneAsync(4); //collected mainly low memories
        } else if (total >= 3500 && total <10000){
            SceneManager.LoadSceneAsync(5); //collected mainly medium memories
        } else if (total >= 10000 && total <30000){
            SceneManager.LoadSceneAsync(6); //collected 1 or 2 high memories
        } else if (total >= 30000){
            SceneManager.LoadSceneAsync(7); //collected all high memories
        }
    }
        
}
