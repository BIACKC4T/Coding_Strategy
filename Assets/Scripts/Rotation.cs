using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // ȸ�� �ӵ��� ������ ����
    public float rotationSpeed = 30f;

    // �� �����Ӹ��� ȣ��Ǵ� �Լ�
    void Update()
    {
        // ������Ʈ�� ȸ����ŵ�ϴ�.
        // Vector3.up�� y���� �������� ȸ���� ��Ÿ���ϴ�. �ٸ� ���� �������� ȸ���Ϸ��� ������ �� �ֽ��ϴ�.
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}