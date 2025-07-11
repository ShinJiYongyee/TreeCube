using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float sunSpeed = 288f;

    void Update()
    {
        transform.rotation = Quaternion.Euler(Mathf.Abs((Time.time * sunSpeed) % 180), 30, 0);
    }
}
