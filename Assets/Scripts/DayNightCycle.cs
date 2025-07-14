using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    float sunRotationSpeed = 144f;  // ���� �ӵ�
    float sunOrbitSpeed = 15f;      // ���� �ӵ�

    void Update()
    {
        transform.rotation = Quaternion.Euler(
            Mathf.Abs((Time.time * sunRotationSpeed) % 180), 
            (Time.time * sunOrbitSpeed) % 360, 
            0
            );
    }
}
