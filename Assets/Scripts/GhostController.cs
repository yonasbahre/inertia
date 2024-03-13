using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    
    public GameObject ghostCar;
    private GhostRecord record;
    private bool paused = true;
    private int currFrame = 0;

    void FixedUpdate()
    {
        if (paused || record == null)
            return;
        
        if (currFrame >= record.positions.Count)
        {
            Pause();
            return;
        }
        
        ghostCar.transform.position = record.positions[currFrame];
        ghostCar.transform.rotation = record.rotations[currFrame];

        currFrame++;
    }

    public void SetRecord(GhostRecord _record)
    {
        record = _record;
    }

    public void Play()
    {
        paused = false;
        ghostCar.SetActive(true);
    }

    public void Pause()
    {
        paused = true;
        ghostCar.SetActive(false);
    }

    public void Reset()
    {
        Pause();
        currFrame = 0;
    }
}
