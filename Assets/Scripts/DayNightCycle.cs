using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    float sunRotationSpeed = 72f;  // ���� �ӵ�
    float sunOrbitSpeed = 7.5f;      // ���� �ӵ�

    void Update()
    {
        transform.rotation = Quaternion.Euler(
            Mathf.Abs((Time.time * sunRotationSpeed) % 180), 
            (Time.time * sunOrbitSpeed) % 360, 
            0
            );
    }
}
