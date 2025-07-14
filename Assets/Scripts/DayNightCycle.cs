using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    float sunRotationSpeed = 288f;
    float sunOrbitSpeed = 30f;

    void Update()
    {
        transform.rotation = Quaternion.Euler(
            Mathf.Abs((Time.time * sunRotationSpeed) % 180), 
            (Time.time * sunOrbitSpeed) % 360, 
            0
            );
    }
}
