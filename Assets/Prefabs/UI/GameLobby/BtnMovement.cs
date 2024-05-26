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

    public static int activeAnimations = 0;

    private SoundManager soundManager;


    public void AnimateButton()
    {
        // ȿ������ �ҷ����� ����մϴ�.
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameLobby_UI_ClickSound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f, 0.8f);
        Debug.Log("Btn Sound is comming out!");

        Vector3 originalPos = this.transform.position;
        Vector3 targetPos = originalPos + new Vector3(50, -40, 0);
        
        if (isAnimating) // �ִϸ��̼��� �̹� ���� ���̸�
        {
            Debug.Log("Animation is already in progress."); // �޽����� ����ϰ�
            return; // �Լ��� �����մϴ�.
        }

        isAnimating = true;

        DG.Tweening.Sequence sequence = DOTween.Sequence();

        // �ִϸ��̼� ���� �� activeAnimations ���� ����
        sequence.AppendCallback(() =>
        {
            activeAnimations++;
            scrollView.enabled = false;
        });

        sequence.Append(this.transform.DOMove(targetPos, 0.5f));
        sequence.Append(this.transform.DOMove(originalPos, 0.25f));

        // �ִϸ��̼� ���� �� activeAnimations ���� ����
        sequence.AppendCallback(() =>
        {
            activeAnimations--;
            isAnimating = false;
            if (activeAnimations == 0)
            {
                scrollView.enabled = true;
            }
        });
    }
}