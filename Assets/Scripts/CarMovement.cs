using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    private int numberOfRoadsCollidedWith = 0;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public float accelForce = 1.0f;

    public float brakeForce = 0.5f;

    public float rotationForce = 0.1f;

    void FixedUpdate()
    {
        if (numberOfRoadsCollidedWith <= 0)
        {
            return;
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && rigidbody.velocity.z < 50) 
        {
            rigidbody.AddForce(accelForce * transform.forward);
        }
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && rigidbody.velocity.z > -10)
        {
            rigidbody.AddForce(-brakeForce * transform.forward);
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && rigidbody.velocity.z != 0)
        {
            transform.Rotate(-rotationForce * Vector3.up);
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && rigidbody.velocity.z != 0)
        {
            transform.Rotate(rotationForce * Vector3.up);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            numberOfRoadsCollidedWith++;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            numberOfRoadsCollidedWith--;
        }
    }
}
