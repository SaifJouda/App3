using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    

    public Text timeCounter;
    private TimeSpan timePlaying;
    private bool timerGoing;
    public float elapsedTime;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        //if(timerGoing)
            //StopCoroutine(UpdateTimer());
        
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void ContinueTimer()
    {
        timerGoing=true;
    }

    public void EndTimer()
    {
        timerGoing = false;
        StopCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        
        while (timerGoing)
        {
            elapsedTime +=Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text=timePlayingStr;

            yield return null;
        }
    }
    
   
}
