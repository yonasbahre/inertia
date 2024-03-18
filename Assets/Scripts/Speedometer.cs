using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Speedometer : MonoBehaviour
{
    public TMP_Text speedText;
    public Rigidbody carRigidbody;
    public GameObject needle;
    public float maxSpeed = 50.0f;

    void Start()
    {
        speedText.text = "0";
    }


    void Update()
    {
        float speed = carRigidbody.velocity.magnitude;
        speedText.text = ((int) (3.5f * speed)).ToString();
        UpdateNeedle(speed);
    }

    private void UpdateNeedle(float speed)
    {
        float angle = (speed / maxSpeed) * 180;
        needle.transform.eulerAngles = angle * Vector3.back;
    }
}
