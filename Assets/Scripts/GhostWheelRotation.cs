using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostWheelRotation : MonoBehaviour
{
    public Transform frontLeft;
    public Transform frontRight;
    public Transform backLeft;
    public Transform backRight;

    public float rotationSpeedFactor = 1.0f;

    private List<Transform> tires;
    private float circumference = 1.0f;
    
    void Start()
    {
        tires = new List<Transform>{frontLeft, frontRight, backLeft, backRight};
        float diameter = frontLeft.GetComponent<Renderer>().bounds.size.z;
        circumference = diameter * Mathf.PI;
    }


    public void Rotate(Vector3 currPosition, Vector3 prevPosition)
    {
        Vector3 diff = currPosition - prevPosition;
        float rotationAmount = 
            360 * rotationSpeedFactor * (diff.magnitude / circumference);

        foreach (Transform tire in tires)
        {            
            tire.eulerAngles += new Vector3(-rotationAmount, 0, 0);
        }
    }
}
