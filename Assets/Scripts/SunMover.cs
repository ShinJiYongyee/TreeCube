using UnityEngine;

public class SunMover : MonoBehaviour
{
    float sunRotationSpeed = 72f;  // 자전 속도
    float sunOrbitSpeed = 7.5f;      // 공전 속도

    void Update()
    {
        transform.rotation = Quaternion.Euler(
            0,
            (Time.time * sunOrbitSpeed) % 360 + 90,
            Mathf.Abs((Time.time * sunRotationSpeed) % 180)
            );
    }
}
