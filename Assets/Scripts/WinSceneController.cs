using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneController : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text newRecordText;
    public TMP_Text lessThan2MinsText;
    
    void Start()
    {
        // For testing
        // GhostRecordStore.lastRaceRecord = new GhostRecord();
        // GhostRecordStore.lastRaceRecord.time = 0;
        
        timeText.text = RaceClock.FormatTime(
            GhostRecordStore.lastRaceRecord.time
        );

        GhostRecord prevRecord = 
            GhostRecord.LoadFromPrefs(GhostRecordSelector.GHOST_RECORD_KEY);
    
        if (prevRecord == null || prevRecord.time > GhostRecordStore.lastRaceRecord.time)
        {
            newRecordText.gameObject.SetActive(true);

            if (GhostRecordStore.lastRaceRecord.time < 120.0f)
            {
                GhostRecordStore.lastRaceRecord.SaveToPrefs(
                    GhostRecordSelector.GHOST_RECORD_KEY
                );
            }
            else
            {
                lessThan2MinsText.gameObject.SetActive(true);
            }
        }
    
    }

    public void ReturnToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
