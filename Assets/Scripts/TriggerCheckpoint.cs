using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckpoint : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "Player")
            return;

        Checkpoint checkpoint = transform.parent.gameObject.GetComponent<Checkpoint>();
        checkpoint.BrodcastHit();
    }
}
