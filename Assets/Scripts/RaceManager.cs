using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceManager : MonoBehaviour
{
    public RaceClock clock;
    public CheckpointManager checkpointManager;
    public CheckpointTeleport teleporter;
    public CarMovement movement;

    public TMP_Text countdownUi;

    private bool countdownInProgress = true;
    
    void Start()
    {
        StartCountdown();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !countdownInProgress)
        {
            StartCountdown();
        }
    }

    public void StartCountdown()
    {
        countdownInProgress = true;
        
        movement.canMove = false;
        checkpointManager.Reset();
        teleporter.ToStartCheckpoint();
        
        clock.PauseClock();
        clock.Reset();

        StartCoroutine(RunCountdownTimer());
    }

    private IEnumerator RunCountdownTimer()
    {
        int secondsLeft = 3;
        countdownUi.gameObject.SetActive(true);

        while (secondsLeft > 0)
        {
            countdownUi.text = secondsLeft.ToString();
            yield return new WaitForSeconds(1);
            secondsLeft--;
        }
        
        countdownInProgress = false;
        countdownUi.text = "GO!";
        StartRace();
        StartCoroutine(HideCountdownUi());
    }

    private void StartRace()
    {
        clock.StartClock();
        movement.canMove = true;
    }

    private IEnumerator HideCountdownUi()
    {
        yield return new WaitForSeconds(1);
        countdownUi.gameObject.SetActive(false);
    }
}
