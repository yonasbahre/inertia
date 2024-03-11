using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public CheckpointTeleport teleporter;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "Player")
            return;

        teleporter.ToPrevCheckpoint();
    }
}
