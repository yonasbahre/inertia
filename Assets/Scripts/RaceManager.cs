using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditorInternal;

public class RaceManager : MonoBehaviour
{
    public RaceClock clock;
    public CheckpointManager checkpointManager;
    public CheckpointTeleport teleporter;
    public CarMovement movement;

    public GhostRecorder ghostRecorder;
    public GhostController ghostController;

    public TMP_Text countdownUi;

    private bool countdownInProgress = true;
    private string GHOST_RECORD_KEY = "bestlap";
    
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

        ghostController.Reset();
        ghostRecorder.Reset();

        GhostRecord record = GhostRecord.LoadFromPrefs(GHOST_RECORD_KEY);
        ghostController.SetRecord(record);

        countdownUi.gameObject.SetActive(true);
        StartCoroutine(RunCountdownTimer());
    }

    private IEnumerator RunCountdownTimer()
    {
        int secondsLeft = 3;

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
        ghostController.Play();
        ghostRecorder.Record();
    }

    private IEnumerator HideCountdownUi()
    {
        yield return new WaitForSeconds(1);
        countdownUi.gameObject.SetActive(false);
    }

    public void WinGame()
    {
        Debug.Log("## You win!");

        ghostController.Pause();
        ghostRecorder.FinishLap(clock.currTime);
        ghostRecorder.record.SaveToPrefs(GHOST_RECORD_KEY);
    }

    public void OnEnable()
    {
        CheckpointManager.WinGameEvent += WinGame;
    }

    public void OnDisable()
    {
        CheckpointManager.WinGameEvent -= WinGame;
    }
}
