using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    
    public GameObject ghostCar;
    public GhostWheelRotation wheelRotation;

    private GhostRecord record;
    private bool paused = true;
    private int currFrame = 0;

    private GhostTireSmoke tireSmoke;

    void Awake()
    {
        tireSmoke = ghostCar.GetComponent<GhostTireSmoke>();
    }

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
        
        if (wheelRotation && currFrame > 0)
        {
            wheelRotation.Rotate(
                record.positions[currFrame],
                record.positions[currFrame - 1]
            );
        }

        if (tireSmoke && currFrame > 0)
        {
            tireSmoke.GenerateSmoke(
                record.positions[currFrame],
                record.positions[currFrame - 1]
            );
        }

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
