using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static event System.Action<Checkpoint> CheckpointHitEvent;

    public Checkpoint nextCheckpoint;

    [HideInInspector]
    public Transform spawnPoint;

    void Awake()
    {
        spawnPoint = transform.Find("SpawnPoint");
    }

    public void BrodcastHit()
    {
        CheckpointHitEvent?.Invoke(this);
    }
    
}
