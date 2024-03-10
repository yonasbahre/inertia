using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngle : MonoBehaviour
{
    public GameObject car;
    
    void Update()
    {
        Rigidbody rigidbody = car.GetComponent<Rigidbody>();

        transform.eulerAngles = 
            Vector3.Angle(rigidbody.velocity, rigidbody.GetAccumulatedForce()) * 
            new Vector3(0, -1, 0);
    }
}
