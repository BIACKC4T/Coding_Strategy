using UnityEngine;
using System.Collections;
using DG.Tweening;

public class LilbotController : MonoBehaviour
{
    public Animator animator;
    
    public bool Jump;
    public bool attack1;
    public bool attack2;
    public bool Hit;
    public bool Death;

    public float duration = 1f;
    public Camera playercamera;

    public IEnumerator Walk(float speed, int x, int z)
    {
        //speed�� ���� 1�� ������ �������� �޸��� �ִϸ��̼��� Ʋ�����ſ���.
        //1�̸� ������ �޸���, 0.5�� �ѹ�ѹ� �ȱ�, 0�̸� ������ ���ֱ⸦ �����մϴ�.
        animator.SetFloat("Speed", speed);


        // ���� ��ü�� (x, y, z) ��ġ�� speed �ӵ��� �̵��մϴ�. �׷��ϱ�, �츮
        Vector3 targetPosition = new Vector3(x, transform.position.y, z);


        // DoTween�� DoMove �Լ��� ����Ͽ� �̵��մϴ�.
        transform.DOMove(targetPosition, duration).SetEase(Ease.Linear);


        // �̵� �Ϸ���� ��ٸ��ϴ�.
        yield return new WaitForSeconds(duration);


        // �̵��� �Ϸ�Ǹ� �ִϸ��̼� Speed�� 0���� �����Ͽ� Idle ���·� ���ư��ϴ�.
        animator.SetFloat("Speed", 0);
    }
    
    public IEnumerator JumpAnimationCoroutine()
    {
        animator.SetTrigger("Jump");
        yield return new WaitForSeconds(1);   // 1�� ���
        animator.ResetTrigger("Jump");
    }




    #region attack_Animation
    public void Attack1()
    {
        animator.SetTrigger("Attack1");
    }

    public void Attack2()
    {
        animator.SetTrigger("Attack2");
    }
    #endregion



    #region Death_Animation
    public IEnumerator DeathAnimationCoroutine()
    {
        animator.SetTrigger("Death");

        playercamera.DOShakePosition(1, 5);
        yield return new WaitForSeconds(1);   // 1�� ���
        animator.ResetTrigger("Death");
    }
    #endregion



    #region Hit_Animation
    //�ǰ��� ���� �ִϸ��̼� �۾��� �����մϴ�.
    public IEnumerator HitAnimationCoroutine()
    {
        animator.SetTrigger("Hit");
        playercamera.DOShakePosition(1, 3);
        yield return new WaitForSeconds(1);   // 1�� ���
        animator.ResetTrigger("Hit");
    }
    #endregion

}