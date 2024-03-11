using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireSmoke : MonoBehaviour
{
    public Rigidbody playerCar;
    
    void Start()
    {
        
    }

    void Update()
    {
        float driftAngle = Vector3.Angle(
            playerCar.velocity,
            playerCar.gameObject.transform.forward
        );

        Debug.Log("Angle: " + driftAngle);
    }
}
