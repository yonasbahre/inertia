using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
    [HideInInspector]
    public GhostRecord record = new GhostRecord();
    public Transform car;

    private bool paused = true;

    void Start()
    {
        Reset();
    }
    
    void FixedUpdate()
    {
        if (paused)
            return;

        record.positions.Add(car.position);
        record.rotations.Add(car.rotation);
    }
    
    public void Record()
    {
        paused = false;
    }

    public void Pause()
    {
        paused = true;
    }

    public void Reset()
    {
        Pause();
        record = new GhostRecord();
    }

    public void FinishLap(float lapTime)
    {
        Pause();
        record.time = lapTime;
    }
}
