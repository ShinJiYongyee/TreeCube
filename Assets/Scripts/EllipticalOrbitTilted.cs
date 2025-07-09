using UnityEngine;

public class EllipticalOrbitTilted : MonoBehaviour
{
    public Transform center;           // ���� �߽�
    public float X = 0.3f;               // X��(����)
    public float Z = 1.0f;               // Z��(����)
    public float speed = 1f;           // ���� �ӵ� (���ӵ�)
    public float inclination = 30f;    // �˵� ���� (�� ����)
    public float lookAheadAngle = 0.01f; // ���� ���� ������ ����

    private float angle = 0f;

    void Update()
    {
        // ���� ���� ������Ʈ
        angle += speed * Time.deltaTime;

        // ����� �̷� ������ �������� Ÿ�� ���� ���� ��ġ ���
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

        // �˵� ���� ���� (x���� �������� ȸ��)
        Quaternion tilt = Quaternion.Euler(inclination, 0f, 0f);

        // ������ ��ġ ���
        Vector3 worldCurrentPos = center.position + tilt * localCurrentPos;
        Vector3 worldFuturePos = center.position + tilt * localFuturePos;

        // ��ġ �̵�
        transform.position = worldCurrentPos;

        // ���� ���� �ٶ󺸰� ȸ��
        Vector3 direction = (worldFuturePos - worldCurrentPos).normalized;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
