using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 태그를 사용하여 동적 생성된 구슬인지 확인
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
        }
    }
}

