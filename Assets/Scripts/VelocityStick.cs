using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityStick : MonoBehaviour
{
    public GameObject car;

    void Update()
    {
        transform.LookAt(car.GetComponent<Rigidbody>().velocity + car.transform.position);
    }
}
