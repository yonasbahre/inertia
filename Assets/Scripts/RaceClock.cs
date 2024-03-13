using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceClock : MonoBehaviour
{
    public TMP_Text clockUi;
    
    public float currTime = 0.0f;
    private bool stopped = false;

    void Update()
    {
        if (stopped)
            return;
        
        currTime += Time.deltaTime;
        UpdateUi();
    }

    public void Reset()
    {
        currTime = 0.0f;
        UpdateUi();
    }

    public void StartClock()
    {
        stopped = false;
    }

    public void PauseClock()
    {
        stopped = true;
    }

    private string FormatTime(float time)
    {
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(time);

        return timeSpan.Minutes.ToString("00") + ":" +
            timeSpan.Seconds.ToString("00") + "." + 
            timeSpan.Milliseconds.ToString("000");
    }

    private void UpdateUi()
    {
        clockUi.text = FormatTime(currTime);
    }
}
