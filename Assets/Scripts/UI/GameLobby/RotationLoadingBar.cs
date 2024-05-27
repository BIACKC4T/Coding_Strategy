using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodingStrategy.UI.GameLobby
{
    public class RotationLoadingBar : MonoBehaviour
    {
        public Image loadingImage; // ȸ���� �̹����� �Ҵ�
        public float rotationSpeed = 100f; // �̹����� ȸ�� �ӵ�

        void Update()
        {
            // �� �����Ӹ��� �̹����� ȸ����ŵ�ϴ�
            loadingImage.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
