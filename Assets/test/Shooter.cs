using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject ballPrefab; // 구슬 프리팹
    public Transform spawnPoint;  // 구슬이 생성될 위치

    public float launchForce;  // 현재 발사 힘
    private float chargeRate = 64f; // 힘을 충전하는 비율 (초당)
    private float maxLaunchForce = 100f; // 최대 발사 힘
    private float minLaunchForce = 36f; // 최소 발사 힘
    private GameObject currentBall; // 현재 발사 대기 중인 구슬

    private void Start()
    {
        CreateNewBall();
        launchForce = minLaunchForce; // 발사 힘 초기화
    }

    private void Update()
    {
        // 스페이스바를 누르고 있는 경우
        if (Input.GetKey(KeyCode.Space))
        {
            launchForce = Mathf.Min(launchForce + chargeRate * Time.deltaTime, maxLaunchForce);
        }

        // 스페이스바를 놓은 경우
        if (Input.GetKeyUp(KeyCode.Space) && currentBall != null)
        {
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        currentBall.GetComponent<Rigidbody>().AddForce(Vector3.up * launchForce, ForceMode.Impulse);
        launchForce = minLaunchForce; // 발사 힘 초기화
        CreateNewBall();
    }

    private void CreateNewBall()
    {
        currentBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
    }
}
