using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NUnit.Framework.Internal;

namespace CodingStrategy.Entities.Animations
{
    public class TileAttackAnimation : MonoBehaviour
    {
        
        private Color originalColor;
        public Material newMaterial;


        private void Awake()
        {
            newMaterial = gameObject.GetComponent<Renderer>().material;
            originalColor = newMaterial.color; // ���� ���� ����

        }

        private void Update()
        {
            if(Input.GetKey(KeyCode.K))
            {
                Color test = Color.cyan;
                StartCoroutine(AttackArea(test));
            }
        }

        public IEnumerator AttackArea(Color color)
        {
            
            // ���ÿ� ������ �ִϸ��̼ǵ��� ���� Sequence�� �����մϴ�.

            Sequence sequence = DOTween.Sequence();
            
            // �Ʒ��� �������� �ִϸ��̼ǰ� ���� ���� �ִϸ��̼�
            Vector3 downPosition = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            
            sequence.Append(transform.DOMove(downPosition, 0.75f).SetEase(Ease.InOutSine)); // 0.75�� ���� �Ʒ��� �̵�
            sequence.Join(newMaterial.DOColor(color, 0.75f)); // 0.75�� ���� ������ �Է°����� ����
            
            // ���� ��ġ�� ���ư��� �ִϸ��̼ǰ� ���� �������� �ǵ����� �ִϸ��̼�
            sequence.Append(transform.DOMove(transform.position, 0.25f).SetEase(Ease.InOutSine)); // 0.25�� ���� ���� ��ġ�� �̵�
            sequence.Join(newMaterial.DOColor(originalColor, 0.25f)); // 0.25�� ���� ������ ���� �������� �ǵ���
            
            // Sequence�� �����մϴ�.
            yield return sequence.WaitForCompletion();

        }
    }
}
