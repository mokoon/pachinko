using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // �±׸� ����Ͽ� ���� ������ �������� Ȯ��
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
        }
    }
}

