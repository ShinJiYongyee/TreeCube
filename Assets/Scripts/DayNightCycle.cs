using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    float sunRotationSpeed = 72f;  // 자전 속도
    float sunOrbitSpeed = 7.5f;      // 공전 속도

    void Update()
    {
        transform.rotation = Quaternion.Euler(
            Mathf.Abs((Time.time * sunRotationSpeed) % 180), 
            (Time.time * sunOrbitSpeed) % 360, 
            0
            );
    }
}
