using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MoveAndRotate : MonoBehaviour
{
    public float rotationSpeed = 50f; // ��ŭ ȸ��
    public float moveSpeed = 0.6f; // ��ŭ ������
    public float moveRange = 0.3f; // ��ŭ �̵�

    private Vector3 startPosition; // ������Ʈ ��ġ ���� ����
    [SerializeField] AudioSource musicsource;

    private void Start()
    {
        startPosition = transform.position; // ������ ��ġ ����
        musicsource.time = 0.3f; // ������ 0.3�ʺ��� ����
    }

//��Ʈ�� �������� �� ȸ�� �� ������ �̵��� 
    private void Update()
    {
        // Rotate around the z-axis at the specified speed
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        // Move up and down within the specified range at the specified speed
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

// ��Ʈ�� �԰� �� ��� �����Ű�� �Ǵ� �Լ��Դϴ�.
    public void GetBit()
    {
        rotationSpeed = 1000f;
        moveSpeed = 10f;
        moveRange = 2f;

        musicsource.Play();
        Destroy(gameObject, 0.47f);
    }
}