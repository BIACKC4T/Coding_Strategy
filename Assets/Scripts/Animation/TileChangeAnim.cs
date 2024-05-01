using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class TileChangeAnim : MonoBehaviour
{
    // �ִϸ��̼��� ǥ���� Tile�Դϴ�.
    public GameObject Tile;

    // ��ġ�� �����̻���Դϴ�.
    public GameObject stack;
    public GameObject troijan;
    public GameObject warm;
    public GameObject malware;
    public GameObject spyware;
    public GameObject adware;

    public int TileIndex = -1;
    
    public void TileChange(int TileIndex)
    {
        //   �Ʒ��� dotween ���û����Դϴ�. Dotween�� �ִϸ��̼��� ���������� ť�� �߰��Ͽ� ������� �����մϴ�.
        //   �������� �ִϸ��̼��� ��� ���ʰ� ������ ������ �����Ͽ����ϴ�.
        //   
        //   finalSequence = DOTween.Sequence().SetAutoKill(false).Pause()
        //   DOTween.Sequence().SetAutoKill(false).Pause()�� �ݺ� ���θ� �����մϴ�.
        //
        //              Prepend(����) ���� ���ʿ� �߰��ϰ��� �� ��
        //              Append(����) ���� �ڿ� �߰��ϰ��� �� ��
        //              Join(����) �տ� �߰��� ���۰� ���ÿ� �۵��� ��
        //              Insert(�ð�, ����) ������ ������� ���� �ð��� �Ǹ� ������ ��
        //
        //    ������ ���� �����Դϴ�.
        //
        //   .Append(transform.DOMoveX(targetX, 3).SetEase(ease))
        //   .Append(text.DOFade(targetFadeValue, 3))
        //   .Append(transform.GetComponent<Renderer>().material.DOColor(targetColor, 3))
        //   .Append(transform.DOScale(targetScale, 3).SetEase(ease))
        //   .Append(transform.DOShakeRotation(targetShakeDurtation).SetEase(ease))
        //   .Append(text2.DOText(textString, 3));


        // ���� �ǵ��� ������ ������ �����ϴ�.

        // Ÿ�ϸ� ������ �̹����� �ٿ�� ���� �ƴ϶�,
        // ���� ��¦ ����ٰ�
        // �ݹ��� ȸ���ϰ�
        // Ÿ������ �̹����� ����(disable able ���)
        // �Ʒ��� �ٽ� ���� ���� ���Դϴ�.

        Tile.transform.DORotate(new Vector3(0, 0, 180.0f), 1, RotateMode.Fast);
    }
}
