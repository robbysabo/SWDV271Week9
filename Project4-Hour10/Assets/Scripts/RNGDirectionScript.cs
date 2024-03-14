using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNGDirectionScript : VelocityScript
{
    float rngTime = 2; // 2 seconds change random direction
    float currentTime = 0;

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= rngTime)
        {
            rb.velocity = Vector3.zero;
            currentTime = 0;
            float xValue = (Random.value <= 0.5f) ? 1 : -1;
            float zValue = (Random.value <= 0.5f) ? 1 : -1;
            rb.velocity = new Vector3(xValue * startSpeed, 0, zValue * startSpeed);
        }
    }
}
