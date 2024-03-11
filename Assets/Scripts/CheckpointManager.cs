using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Checkpoint startCheckpoint;
    public Checkpoint finalCheckpoint;
    private Checkpoint prevCheckpoint;
    
    public void Start()
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
            Debug.Log("You win!");  // TODO: activate win screen
        }

        if (checkpoint == prevCheckpoint.nextCheckpoint) 
        {
            prevCheckpoint = checkpoint;
            Debug.Log("Advancing Checkpoint!");
        }
    }
}
