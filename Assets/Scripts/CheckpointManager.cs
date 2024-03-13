using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Checkpoint startCheckpoint;
    public Checkpoint finalCheckpoint;

    [HideInInspector]
    public Checkpoint prevCheckpoint;

    public static System.Action WinGameEvent;
    
    public void Start()
    {
        Reset();
    }

    public void Reset()
    {
        prevCheckpoint = startCheckpoint;
    }

    private void OnEnable()
    {
        Checkpoint.CheckpointHitEvent += OnCheckpointHit;
    }

    private void OnDisable()
    {
        Checkpoint.CheckpointHitEvent -= OnCheckpointHit;
    }

    private void OnCheckpointHit(Checkpoint checkpoint)
    {
        if (
            checkpoint == finalCheckpoint &&
            (prevCheckpoint.nextCheckpoint == null || prevCheckpoint.nextCheckpoint == checkpoint)
        ) {
            WinGameEvent?.Invoke();
        }

        if (checkpoint == prevCheckpoint.nextCheckpoint) 
        {
            prevCheckpoint = checkpoint;
        }
    }
}
