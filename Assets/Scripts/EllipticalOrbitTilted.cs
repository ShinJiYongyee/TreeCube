using UnityEngine;

public class EllipticalOrbitTilted : MonoBehaviour
{
    public Transform center;           // 공전 중심
    public float X = 0.3f;               // X축(절대)
    public float Z = 1.0f;               // Z축(절대)
    public float speed = 1f;           // 공전 속도 (각속도)
    public float inclination = 30f;    // 궤도 기울기 (도 단위)
    public float lookAheadAngle = 0.01f; // 진행 방향 예측용 각도

    private float angle = 0f;

    void Update()
    {
        // 공전 각도 업데이트
        angle += speed * Time.deltaTime;

        // 현재와 미래 각도를 기준으로 타원 상의 로컬 위치 계산
        Vector3 localCurrentPos = new Vector3(
            X * Mathf.Cos(angle),
            0f,
            Z * Mathf.Sin(angle)
        );

        Vector3 localFuturePos = new Vector3(
            X * Mathf.Cos(angle + lookAheadAngle),
            0f,
            Z * Mathf.Sin(angle + lookAheadAngle)
        );

        // 궤도 기울기 적용 (x축을 기준으로 회전)
        Quaternion tilt = Quaternion.Euler(inclination, 0f, 0f);

        // 기울어진 위치 계산
        Vector3 worldCurrentPos = center.position + tilt * localCurrentPos;
        Vector3 worldFuturePos = center.position + tilt * localFuturePos;

        // 위치 이동
        transform.position = worldCurrentPos;

        // 진행 방향 바라보게 회전
        Vector3 direction = (worldFuturePos - worldCurrentPos).normalized;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
