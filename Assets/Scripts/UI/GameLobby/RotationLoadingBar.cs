using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodingStrategy.UI.GameLobby
{
    public class RotationLoadingBar : MonoBehaviour
    {
        public float rotationSpeed = 100f; // ȸ�� �ӵ�

        void Update()
        {
            // �� �����Ӹ��� UI ��Ҹ� ȸ����ŵ�ϴ�
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); // Z ���� �߽����� ȸ��
        }
    }
}
