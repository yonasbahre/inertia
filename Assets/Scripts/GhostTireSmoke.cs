using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTireSmoke : MonoBehaviour
{
    public ParticleSystem particlesLeftTire;
    public ParticleSystem particlesRightTire;

    public Transform ghostCar;

    public void GenerateSmoke(Vector3 currPosition, Vector3 prevPosition)
    {
        Vector3 velocity = currPosition - prevPosition;

        float driftAngle = Vector3.Angle(
            velocity,
            ghostCar.gameObject.transform.forward
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
        float factor = 15.0f;
        float biasDegrees = -15.0f;

        return factor * Math.Min(1.0f, ((driftAngle + biasDegrees)/ 90.0f));
    }
}
