using UnityEngine;

public class SunMover : MonoBehaviour
{
    float sunRotationSpeed = 72f;  // ���� �ӵ�
    float sunOrbitSpeed = 7.5f;      // ���� �ӵ�

    void Update()
    {
        transform.rotation = Quaternion.Euler(
            0,
            (Time.time * sunOrbitSpeed) % 360 + 90,
            Mathf.Abs((Time.time * sunRotationSpeed) % 180)
            );
    }
}
