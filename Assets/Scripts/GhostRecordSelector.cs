using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GhostRecordSelector : MonoBehaviour
{
    public static string GHOST_RECORD_KEY = "bestlap";
    
    public TextAsset devRecordAsset;
    public TMP_Text devTimeText;
    public TMP_Text playerTimeText;
    public TMP_Text noPlayerGhostFoundText;
    public Button playerSelectButton;
    
    private GhostRecord devRecord;
    private GhostRecord playerRecord;

    void Start()
    {
        string devJson = devRecordAsset.text;
        devRecord = GhostRecord.FromJson(devJson);

        playerRecord = GhostRecord.LoadFromPrefs(GHOST_RECORD_KEY);
    
        devTimeText.text = RaceClock.FormatTime(devRecord.time);

        if (playerRecord != null)
        {
            playerTimeText.text = RaceClock.FormatTime(playerRecord.time);
        }
        else
        {
            playerTimeText.gameObject.SetActive(false);
            noPlayerGhostFoundText.gameObject.SetActive(true);
            playerSelectButton.interactable = false;
        }
    }

    public void StartRaceAgainstDevGhost()
    {
        GhostRecordStore.record = devRecord;
        SceneManager.LoadScene("Track1");
    }

    public void StartRaceAgainstPlayerGhost()
    {
        GhostRecordStore.record = playerRecord;
        SceneManager.LoadScene("Track1");
    }
}
