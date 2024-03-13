using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireSmoke : MonoBehaviour
{
    public Rigidbody playerCar;
    public CarMovement movement;

    public ParticleSystem particlesLeftTire;
    public ParticleSystem particlesRightTire;
    

    void Update()
    {
        float driftAngle = Vector3.Angle(
            playerCar.velocity,
            playerCar.gameObject.transform.forward
        );

        float intensity = SmokeIntensity(driftAngle);

        var emissionsLeft = particlesLeftTire.emission;
        emissionsLeft.rateOverTime = intensity;
        emissionsLeft.rateOverDistance = 0.5f * intensity;

        var emissionsRight = particlesRightTire.emission;
        emissionsRight.rateOverTime = intensity;
        emissionsRight.rateOverDistance = 0.5f * intensity;
    }

    private float SmokeIntensity(float driftAngle)
    {
        float factor = movement.numberOfRoadsCollidedWith > 0 ? 15.0f : 0.0f;
        float biasDegrees = -15.0f;

        return factor * Math.Min(1.0f, ((driftAngle + biasDegrees)/ 90.0f));
    }
}
