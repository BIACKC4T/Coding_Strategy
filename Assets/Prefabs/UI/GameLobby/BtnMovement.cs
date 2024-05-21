using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;

public class BtnMovement : MonoBehaviour
{
    public ScrollRect scrollView; // ��ũ�Ѻ信 ���� ������ �����մϴ�.
    private Vector3 originalPos; // �ִϸ��̼� ���� ���� ��ġ�� �����մϴ�.
    private bool isAnimating = false; // �ִϸ��̼� ���¸� �����ϴ� �÷��� �����Դϴ�.

    public void AnimateButton()
    {
        if (isAnimating) // �ִϸ��̼��� �̹� ���� ���̸�
        {
            Debug.Log("Animation is already in progress."); // �޽����� ����ϰ�
            return; // �Լ��� �����մϴ�.
        }

        isAnimating = true; // �ִϸ��̼� ���¸� '���� ��'���� �����մϴ�.

        Vector3 originalPos = this.transform.position; // ������Ʈ�� ���� ��ġ�� �����մϴ�.
        Vector3 targetPos = originalPos + new Vector3(50, -40, 0); // ��ǥ ��ġ�� ����մϴ�.

        DG.Tweening.Sequence sequence = DG.Tweening.DOTween.Sequence(); // ���ο� DoTween �������� �����մϴ�.
        sequence.AppendCallback(() => scrollView.enabled = false); // �ִϸ��̼� ���� �� ��ũ�Ѻ並 ��Ȱ��ȭ�մϴ�.
        sequence.Append(this.transform.DOMove(targetPos, 0.5f)); // ������Ʈ�� ��ǥ ��ġ�� 0.5�� ���� �̵���ŵ�ϴ�.
        sequence.Append(this.transform.DOMove(originalPos, 0.5f)); // ������Ʈ�� ���� ��ġ�� 0.5�� ���� �̵���ŵ�ϴ�.
        sequence.AppendCallback(() =>
        {
            scrollView.enabled = true; // �ִϸ��̼��� ������ ��ũ�Ѻ並 �ٽ� Ȱ��ȭ�մϴ�.
            isAnimating = false; // �ִϸ��̼� ���¸� '����'�� �����մϴ�.
        });
    }
}
