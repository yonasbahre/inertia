using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTeleport : MonoBehaviour
{
    public CheckpointManager checkpointManager;
    public GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToPrevCheckpoint();
        }
    }

    public void ToCheckpoint(Checkpoint checkpoint)
    {
        player.transform.position = checkpoint.spawnPoint.position;
        player.transform.rotation = checkpoint.spawnPoint.rotation;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void ToPrevCheckpoint()
    {
        ToCheckpoint(checkpointManager.prevCheckpoint);
    }

    public void ToStartCheckpoint()
    {
        ToCheckpoint(checkpointManager.startCheckpoint);
        // TODO: reset prev checkpoint
    }
}
