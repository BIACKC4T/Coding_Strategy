using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject tile;

    public IEnumerator BounceEffect(Rigidbody tileRigidbody)
    {
        
        
        Vector3 originalPosition = transform.position;
        Vector3 scale = transform.localScale;


        // �Ʒ��� ���� �������ϴ�.
        yield return transform.DOMoveY(transform.position.y - 0.1f, 0.2f).WaitForCompletion();

        // y�� �������� 0.6 �ٿ��� �ٸ� ������Ʈ��� ���̸� ����ϴ�.
        scale.y = 0.6f;
        // Y ��ġ�� 0.3���� �����մϴ�.
        transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);

        this.gameObject.transform.localScale = scale;
        
        // �ٽ� ���� ��ġ�� ���ƿɴϴ�.
        yield return transform.DOMoveY(originalPosition.y, 0.2f).WaitForCompletion();

        if (tileRigidbody != null)
        {
            tileRigidbody.isKinematic = true;
        }
    }
}