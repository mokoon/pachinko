using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject ballPrefab; // ���� ������
    public Transform spawnPoint;  // ������ ������ ��ġ

    public float launchForce;  // ���� �߻� ��
    private float chargeRate = 64f; // ���� �����ϴ� ���� (�ʴ�)
    private float maxLaunchForce = 100f; // �ִ� �߻� ��
    private float minLaunchForce = 36f; // �ּ� �߻� ��
    private GameObject currentBall; // ���� �߻� ��� ���� ����

    private void Start()
    {
        CreateNewBall();
        launchForce = minLaunchForce; // �߻� �� �ʱ�ȭ
    }

    private void Update()
    {
        // �����̽��ٸ� ������ �ִ� ���
        if (Input.GetKey(KeyCode.Space))
        {
            launchForce = Mathf.Min(launchForce + chargeRate * Time.deltaTime, maxLaunchForce);
        }

        // �����̽��ٸ� ���� ���
        if (Input.GetKeyUp(KeyCode.Space) && currentBall != null)
        {
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        currentBall.GetComponent<Rigidbody>().AddForce(Vector3.up * launchForce, ForceMode.Impulse);
        launchForce = minLaunchForce; // �߻� �� �ʱ�ȭ
        CreateNewBall();
    }

    private void CreateNewBall()
    {
        currentBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
    }
}
