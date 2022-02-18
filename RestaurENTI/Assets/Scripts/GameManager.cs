using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float timeRemaining = 90;
    [SerializeField] bool timerIsRunning = false;
    
    [SerializeField] Text timeText;
    [SerializeField] RestaurentiDB database;

    public bool victory;
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        victory = false;
        timerIsRunning = true;
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }
    void Update()
    {
        CheckVictory();
        if (timerIsRunning)
        {
            if (timeRemaining < 59)
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            /*else
            {
                Debug.Log("Lentorro!");
                timeRemaining = 0;
                timerIsRunning = false;
            }*/
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        //timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void CheckVictory()
    {
        if (victory != false)
        {
            audioData.Pause();
            timerIsRunning = false;
        }
        else if (victory == false)
        {
            timerIsRunning = true;
            audioData.UnPause();
        }
    }
}
